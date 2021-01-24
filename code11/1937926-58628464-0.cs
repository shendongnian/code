@page "/"
@model IndexModel
<div>
    <!--Call the C# class foo() method-->
    @Foo()
</div>
Your Index.cshtml.cs:
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace MyProject.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
        }
        public void OnGet()
        {
        }
        public static string Foo()
        {
            return "This is a foo string through C#";
        }
    }
}
Also check out Blazor.
EDIT: There is more needed to get this example to work. Since you started with an empty project you would have to setup Program.cs, Startup.cs, make a _Layout.cshtml to handle the head/body for each page... It's better to start with a Razor Pages template instead.
EDIT 2: I realize now you are using ASP .NET, not ASP .NET Core. ASP .NET does not have Razor Pages, sorry. You should consider using Core. It's the future of .NET and will meet all of your needs and be more performant.
