        [Route("Default")]
        public class HomeController : Controller
        {
            [Route("DownloadApp")]
            public IActionResult DownloadApp()
            {
                //you code here
                return View();
            }
            [Route("ResetPassword")]
            public IActionResult ResetPassword()
            {
               //you code here
               return View("Index");
            }
        }
