    protected FileResult HandleDataToFileResult(IEnumerable<UP> data)
    {
        return new XLSFileResult()
        {
            Data = data,
            FileDownloadName = "MyFile.xls" //by virtue of this assignment, a 'Content-Disposition' Response.Header is added to HttpResponseBase
        };
    }
    public FileResult GenerateFile()
    {
        var data = (IEnumerable<UP>)TempData["GenerateFile"];
        return HandleDataToFileResult(data);
    }
