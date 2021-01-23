    public string SaveFile(HttpPostedFileBase uploadfile, string saveInDirectory="/", List<string> acceptedExtention =null)
    {
        acceptedExtention = acceptedExtention ?? new List<String>() {".png", ".Jpeg"};//optional arguments
        var extension = Path.GetExtension(uploadfile.FileName).ToLower();
        if (!acceptedExtention.Contains(extension))
        {
            throw new UserFriendlyException("Unsupported File type");
        }
        var tempPath = GenerateDocumentPath(uploadfile.FileName, saveInDirectory);
        FileHelper.DeleteIfExists(tempPath);
        uploadfile.SaveAs(tempPath);
        var fileName = Path.GetFileName(tempPath);
        return fileName;
    }
    private string GenerateDocumentPath(string fileName, string saveInDirectory)
    {
        System.IO.Directory.CreateDirectory(Server.MapPath($"~/{saveInDirectory}"));
        return Path.Combine(Server.MapPath($"~/{saveInDirectory}"), fileName + DateTime.Now.Ticks);
    }
