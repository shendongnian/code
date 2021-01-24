<PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.2.0" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.WebApiCompatShim" Version="2.2.0" />
and now my test project looks like this
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="nunit" Version="3.11.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.2.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.WebApiCompatShim" Version="2.2.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="3.13.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.9.0" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\FunctionExampleFunction\FunctionExampleFunction.csproj" />
  </ItemGroup>
</Project>
To mock the services that the `ArgumentNullException` was implying were missing (which in this case I think are MediaTypeFormatters), I had to essentially bootstrap MVC to get the HttpContext initialized properly.
[Test]
public async Task TestSomeFunction()
{
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Post,
        RequestUri = new Uri("http://localhost/"),
        Content = new StringContent("", Encoding.UTF8, "application/json")
    };
    var services = new ServiceCollection()
        .AddMvc()
        .AddWebApiConventions()
        .Services
        .BuildServiceProvider();
    request.Properties.Add(nameof(HttpContext), new DefaultHttpContext
    {
        RequestServices = services
    });
    var response = await FunctionExample.SomeFunction(request);
    var content = await response.Content.ReadAsStringAsync();
    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    Assert.That(content, Is.EqualTo("\"Bad job\""));
}
And that makes the test compile, run, and pass.
