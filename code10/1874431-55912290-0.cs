    public class HomeController : Controller
    {
        private IHostingEnvironment _env;
        // inject a hosting env so that we can get the wwwroot path
        public HomeController(IHostingEnvironment env){
            this._env = env;
        }
        public IActionResult GetImages()
        {
            // get the real path of wwwroot/imagesFolder
            var rootDir = this._env.WebRootPath;
            // the extensions allowed to show
            var filters = new String[] { ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp", ".svg" };
            // set the base url = "/"
            var baseUrl = "/";
            
            var imgUrls = Directory.EnumerateFiles(rootDir,"*.*",SearchOption.AllDirectories)
                .Where( fileName => filters.Any(filter => fileName.EndsWith(filter)))
                .Select( fileName => Path.GetRelativePath( rootDir, fileName) ) // get relative path
                .Select ( fileName => Path.Combine(baseUrl, fileName))          // prepend the baseUrl
                .Select( fileName => fileName.Replace("\\","/"))                // replace "\" with "/"
                ;
            return new JsonResult(imgUrls);
        }
    }
