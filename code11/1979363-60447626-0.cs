     public class DisplayPDFController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        public DisplayPDFController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(string fileName)
        {
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, @"Files\" + fileName);
            if (System.IO.File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                return "Report was not generated.";
            }
        }
        public FileResult ShowPDF(string path)
        {
            var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            return File(fileStream, "application/pdf");
        }
    }
