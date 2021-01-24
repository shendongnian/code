c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
namespace MyNamespace.Utils{
    public static class AppExtensions{
        private static IEnumerable<string> _GetAreasWithAreaRoot(){
            var cd = Directory.GetCurrentDirectory();
            var directory = new DirectoryInfo(Path.Combine(cd, "Areas"));
            var areas = directory.EnumerateDirectories();
            foreach(var area in areas){
                var wwwarearoot = area.EnumerateDirectories("wwwarearoot").FirstOrDefault();
                if(wwwarearoot != null){
                    yield return wwwarearoot.FullName;
                }
            }
        }
        public static void UseAreaStaticFiles(this IApplicationBuilder app){
            var areas = _GetAreasWithAreaRoot();
            app.UseStaticFiles(new StaticFileOptions{
                FileProvider = new CompositeFileProvider( areas.Select( areawwwroot =>
                    new PhysicalFileProvider(areawwwroot)
                ).ToArray()),
                RequestPath = "/areas",
                ContentTypeProvider = new FileExtensionContentTypeProvider(
                    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        { ".js", "application/javascript" },
                        { ".css", "text/css"}
                    })
            });
        }
    }
}
In my `Startup.cs` I can add 
c#
using MyNamespace.Utils;
...
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...
    app.UseAreaStaticFiles(); // Areas/{area}/wwwarearoot
    ...
}
To ensure that your wwwarearoot files gets included in your published artifacts, you might also want to add the following to your `*.csproj` file
xml
<ItemGroup>
    ...
    <Content Include="Areas\*\wwwarearoot\**">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    ...
</ItemGroup>
