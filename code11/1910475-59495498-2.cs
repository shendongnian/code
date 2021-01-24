    public async Task<JsonResult> DocUploadImage()
            {
                try
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images/vehicle-key");
                    var filePath = Path.Combine(uploads, "rich-text");
                    var urls = new List<string>();
    
                    //If folder of new key is not exist, create the folder.
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
    
                    foreach (var contentFile in Request.Form.Files)
                    {
                        if (contentFile != null && contentFile.Length > 0)
                        {
                            await contentFile.CopyToAsync(new FileStream($"{filePath}\\{contentFile.FileName}", FileMode.Create));
                            urls.Add($"{HttpContext.Request.Host}/rich-text/{contentFile.FileName}");
                        }
                    }
    
                    return Json(urls);
                }
                catch (Exception e)
                {
                    return Json(new { error = new { message = e.Message } });
                }
            }
