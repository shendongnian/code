            string _ApplicationPath = GetCurrentPageName();
            string _URL = Request.Url.ToString();
            string _ReturnString;
            Int32 _Position = _URL.IndexOf(_ApplicationPath);
    
            _ReturnString = _URL.Replace(_ApplicationPath, "");
    
            return _ReturnString;
    
        }
                     public static string GetCurrentPageName()
            {
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;
                return sRet.ToLower();
            }
