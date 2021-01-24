    using Microsoft.AspNetCore.Mvc;
    namespace MyApp.Namespace4
    {
        [Area("Duck")]
        public class UsersController : Controller
        {
            public IActionResult GenerateURLInArea()
            {
                // Uses the 'ambient' value of area
                var url = Url.Action("Index", "Home"); 
                // returns /Manage/Home/Index
                return Content(url);
            }
            public IActionResult GenerateURLOutsideOfArea()
            {
                // Uses the empty value for area
                var url = Url.Action("Index", "Home", new { area = "" }); 
                // returns /Manage
                return Content(url);
            }
        }
    }
