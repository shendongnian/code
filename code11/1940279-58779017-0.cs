    [HttpGet]
    public IActionResult DisplayFile(string filename)
    {
        return new PhysicalFileResult(@"C:\MyProject\UploadedFiles\"+filename, "application/pdf");
    }
