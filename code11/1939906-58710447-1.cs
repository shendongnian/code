    protected FileResult HandleDataToFileResult(IEnumerable<UP> data)
    {
        return new XLSFileResult()
        {
            Data = data,
            FileDownloadName = "MyFile.xls"
        };
    }
    public FileResult GenerateFile()
    {
        var data = (IEnumerable<UP>)TempData["GenerateFile"];
        return HandleDataToFileResult(data);
    }
