    public async Task<IActionResult> FileUpload(IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest();
                }
    
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    using (var img = Image.FromStream(memoryStream))
                    {
                      // TODO: ResizeImage(img, 100, 100);
                    }
                }
            }
