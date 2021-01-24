        using Microsoft.AspNetCore.Hosting;
        using Microsoft.AspNetCore.Mvc;
        public class HomeController : Controller
        {
              private readonly IWebHostEnvironment _hostingEnv;
               public HomeController(IWebHostEnvironment hostingEnv)
               {
                 _hostingEnv = hostingEnv;
               }
              private Void GetWebRoot()
              {
                 var webRootPath = _hostingEnv.WebRootPath;
              }
         }
