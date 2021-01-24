       [HttpGet]
       [Route("download")]
       public async Task<iactionresult> Download([FromQuery] string file) {
           var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
           var filePath = Path.Combine(uploads, file);
           if (!System.IO.File.Exists(filePath))
               return NotFound();
 
           var memory = new MemoryStream();
           using (var stream = new FileStream(filePath, FileMode.Open))
           {
               await stream.CopyToAsync(memory);
           }
           memory.Position = 0;
 
           return File(memory, GetContentType(filePath), file);
       }
