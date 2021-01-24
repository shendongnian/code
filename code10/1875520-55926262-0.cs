    public FileResult PDFToReturn()
    {
        string filePath = Server.MapPath("Path_to_PDF");
        return File(System.IO.File.ReadAllBytes(filePath), System.Web.MimeMapping.GetMimeMapping(filePath));
    }
