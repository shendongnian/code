    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {
        private readonly IWebHostEnvironment environment;
        public DownloadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
    
        [HttpGet("[action]")]
        public IActionResult DownloadFile(string FileName)
        {
            string path = Path.Combine(
                                environment.WebRootPath,
                                "files",
                                FileName);
    
            var stream = new FileStream(path, FileMode.Open);
    
            var result = new FileStreamResult(stream, "text/plain");
            result.FileDownloadName = FileName;
            return result;
        }
    }
