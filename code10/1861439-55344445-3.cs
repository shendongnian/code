    public FileResult GetDataFile(string id, [FromBody] DataLog log)
    {
    	var bytes = System.IO.File.ReadAllBytes("<absolute path of file here>");
    	System.IO.File.Delete("<absolute path of file here>");
    	return File(bytes, "application/octet-stream", "<name of file>");
    }
