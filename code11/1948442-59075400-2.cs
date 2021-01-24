csharp
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                                  name: "areas",
                                  areaName: "Admin",
                                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
5) `Areas\Admin\Controllers\BankHolidaysController.cs`
csharp
using System;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace dotnet_mvc_areas_stack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BankHolidaysController : AbpController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            Console.WriteLine("Creating");
            return View();
        }
    }
}
6) `Areas\Views\BankHolidays\Create.cshtml` with the (degenerated :) ) form
html
<p> This is index page of area </p>
<div>
    <form method="post" action="/Admin/BankHolidays/Create">
        <button type="submit">submit</button>
    </form>
</div>
7) `Create.cshtml` next to it
html
<div>Created</div>
