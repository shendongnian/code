    [HttpPost]
    public IActionResult Download()
    {
        byte[] content = System.IO.File.ReadAllBytes(pathOfTheFile);
        return File(content, "application/zip", filename);
    }
