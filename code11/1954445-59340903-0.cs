    [HttpPost]
    public IActionResult Index(IFormFile file)
    {
        var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images");
    
        var uploadedFileExtn = Path.GetExtension(file.FileName);
        var fileName = Path.ChangeExtension(Guid.NewGuid().ToString("N"), uploadedFileExtn);
        using (var stream = System.IO.File.OpenWrite(Path.Combine(imagePath, fileName)))
        {
            file.CopyTo(stream);
        }
    
        return View();
    }
