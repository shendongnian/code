    [HttpPost("Upload"), DisableRequestSizeLimit]
            public ActionResult Upload()
            {
                try
                {
                    var file = Request.Form.Files[0];
                    var folderName = Path.Combine("Resources","Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
    
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
    
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
    
                        return Ok(new { dbPath });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }
