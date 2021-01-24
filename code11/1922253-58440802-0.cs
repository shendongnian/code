xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" />
  </ItemGroup>
</Project>
And then add the reference to your services collection.
csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers()
            .AddNewtonsoftJson();
}
# Option 2: Use System.Text.Json.Serialization
On the other hand, if you're happy to define your models without `System.Runtime.Serialization` attributes and use the `System.Text.Json.Serialization` attributes instead, then you can do the following:
csharp
using System.Text.Json.Serialization;
namespace WebApplication17.Models
{
    public class TestData
    {
        [JsonPropertyName("testaction")]
        public string Action { get; set; }
    }
}
You can find the full list of supported attributes here: https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonpropertynameattribute?view=netcore-3.0
