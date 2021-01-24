    // GET: Viewer/File
    [HttpGet]
    public FileResult Download(string path)
    {
       byte[] fileBytes = System.IO.File.ReadAllBytes(path);
       string fileName = Path.GetFileName(path);
       return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
