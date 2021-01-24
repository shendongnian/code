    [HttpPost]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> UploadFile()
    {
            try
            {
                var file = Request.Form.Files[0];
                var path = "D:/WordFiles/";
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return return StatusCode(500, ex.Message);
            }
    }
