    public class ImageSaverController : Controller {
        
        //  POST: api/ImageSaver/SaveImage
        [HttpPost()]
        [Route("api/ImageSaver/SaveImage")]
        [ResponseType(typeof(Response))]
        IHttpActionResult SaveImage() {
            Response Response = new Response();
            try {
                if ((HttpContext.Current.Request.Files.Count > 0)) {
                    object file = HttpContext.Current.Request.Files("ImageFile");
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;
                    object max_size_in_byte = 1024000; // 1 megabyte
                    if ((fileSize < max_size_in_byte)) {
                        object image_path = HttpContext.Current.Server.MapPath("~/content/uploads/images/");
                        if (!Directory.Exists(image_path)) {
                            Directory.CreateDirectory(image_path);
                        }
                        
                        file.SaveAs((image_path + fileName));
                        Response.Status = 200;
                        // Constants.ResponseStatusCode.SUCCESS
                        Response.Message = "Record updated successfully";
                    }
                    else {
                        Response.Status = 5550;
                        // Constants.ResponseStatusCode.ERROR_IMAGE_TOO_LARGE
                        Response.Message = "Image too large (max size: 1mb)";
                    }
                    
                }
                
            }
            catch (Exception ex) {
                Response.Status = 403;
                // Constants.ResponseStatusCode.ERROR_CRITICAL
                Response.Message = ex.Message;
            }
            
            return Ok(Response);
        }
        
        public class Response {
            
            public int Status {
            }
        }
    }
