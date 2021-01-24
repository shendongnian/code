    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.PlatformAbstractions;
    using System.IO;
    
    namespace DeafultAPICoreProject.Controllers
    {
        [Route("api/values")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            [Route("download")]
            public IActionResult DownloadFile()
            {
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"TextFile.txt");
    
                var bytes = System.IO.File.ReadAllBytes(filePath);
    
                return File(bytes, "application/octet-stream", "newfile.txt");
    
            }
        }
    }
