    using System.IO;
    using System.Web.Mvc;
    
    namespace SO_web_directory.Controllers
    {
        public class HomeController : Controller
        {
            private static readonly string DefaultDirectory = @"C:\";
    
            public ActionResult Index(string path)
            {
                if (string.IsNullOrWhiteSpace(path))
                    path = DefaultDirectory;
    
                return View(new DirectoryInfo(path).GetDirectories());
            }
        }
    }
