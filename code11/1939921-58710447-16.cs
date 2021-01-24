    public ActionResult Details(int S)
    {
        SLMEntitiesDB dbContext = new SLMEntitiesDB();
        var VL = (from U in dbContext.Users
                  join P in dbContext.Products
                  on U.PID equals P.PID
                  where P.PID == U.PID
                  select new UP()
                  {
                      UserO = U,
                      ProductO = P
                  }).Where(U => U.UserO.LID == S).ToList();
        return View(VL);
    }
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
