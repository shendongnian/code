        public class FileUploadingController : ApiController
    {
        [HttpPost]
        [Route("api/FileUploading/UploadFile")]
        public async Task<ActionResult> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);
    
            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);
    
                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;
    
                    // remove double quotes from string.
                    name = name.Trim('"');
    
                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);
    
                    File.Move(localFileName, filePath);
                }
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
    
            return Ok("File uploaded!"); //or return Content("File uploaded!")
        }
    }
