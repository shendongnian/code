    public FilePathResult DownloadFile(Guid id, string dateiname)
    {
        string pfad = Server.MapPath(@"D:\wwwroot\portal_Daten\");
        var filePath = Path.Combine(pfad, dateiname);
        return File(filePath , "application/pdf", dateiname);
    }
