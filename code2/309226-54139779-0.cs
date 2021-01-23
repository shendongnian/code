    public ActionResult GetFile(string path)
    {
        if (!File.Exists(path))
        {
            return NotFound();
        }
        return new FileContentResult(File.ReadAllBytes(path), "application/octet-stream");
    }
