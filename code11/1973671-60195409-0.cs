    public async Task<string> AddImage(IFormFile image, int id)
    {
        if (image.Length > 0)
        {
            var dir = Path.Combine("images", ("apartamento" + id.ToString()));
            var filePath = Path.Combine(dir, image.FileName);
    
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
    
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
    
            return filePath;
        }
    } 
