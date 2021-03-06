using System.Threading.Tasks;
using FluentAssertions;
using Hestify;
using Wd3w.AspNetCore.EasyTesting.SampleApi.Models;
using Wd3w.AspNetCore.EasyTesting.Test.Common;
using Xunit;

namespace Wd3w.AspNetCore.EasyTesting.Test.SystemUnderTest
{
    public class CreateClientTest : EasyTestingTestBase
    {
        [Fact]
        public async Task Should_ReturnHttpClientAndWork()
        {
            // Given
            // WHen
            var httpClient = SUT.CreateClient();
            var response = await httpClient.Resource("api/sample/data").GetAsync();

            // Then
            var sample = await response.ShouldBeOk<SampleDataResponse>();
            sample.Data.Should().Be("Original Sample Data");
        }
    }
}