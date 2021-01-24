    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MVCCoreUpload.Models;
    
    namespace MVCCoreUpload.Controllers
    {
        public class FileUploadController : Controller
        {
    
            private readonly IHostingEnvironment _hostingEnvironment;
    
            public FileUploadController(IHostingEnvironment hostingEnvironment)
            {
                _hostingEnvironment = hostingEnvironment;
            }
    
            public IActionResult Index()
            {
                return View(new UploadViewModel());
            }
    
            public async Task<IActionResult> CreateAsync(UploadViewModel model)
            {
                try
                {
                    string folder = "FileLocation/";
                    string folderpath = "";
    
                    if (model.Filess != null)
                    {
                        string fileExtension = Path.GetExtension(model.Filess.FileName);
                        fileExtension = fileExtension.ToLower();
    
                        long fileSize = model.Filess.Length;
    
                        if (fileSize <= 10485760)
                        {
                            folderpath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", folder);
                            if (!Directory.Exists(folderpath))
                            {
                                Directory.CreateDirectory(folderpath);
                            }
    
                            var parsedContentDisposition =
                                ContentDispositionHeaderValue.Parse(model.Filess.ContentDisposition);
    
                            var filename = Path.Combine(_hostingEnvironment.WebRootPath,
                                "Uploads", folder, parsedContentDisposition.FileName.Trim('"'));
    
                            using (var stream = System.IO.File.OpenWrite(filename))
                            {
                                await model.Filess.CopyToAsync(stream);
                            }
                        }
                    };
                }
                catch (Exception ex)
                {
    
                }
                return View("index");
            }
        }
    }
 
