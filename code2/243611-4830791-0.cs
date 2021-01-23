    public string GetCurrentPageName() 
    { 
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath; 
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath); 
        string sRet = oInfo.Name; 
        return sRet; 
    } 
