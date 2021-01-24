     public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult Post(Picture picture)
        {
            var pathString = configuration.GetValue<string>("UploadPaths:Pictures");
            var path = Path.Combine(_hostingEnvironment.WebRootPath, pathString, picture.Name);
            return Content(path);
        }
    }
