    public FilePathResult DownloadFile(Guid id, string dateiname)
    {
        string pfad = Server.MapPath(@"D:\wwwroot\portal_Daten\");
    
        return File(pfad + dateiname, "application/pdf", dateiname);
    }
