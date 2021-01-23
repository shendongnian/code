     public static string GetDomainName(System.Web.HttpRequest Request)
        {
                    
            string _ApplicationPath = Request.ApplicationPath;
            string _URL = Request.Url.ToString();
            Int32 _Position = _URL.IndexOf(_ApplicationPath);
               
            if (_Position > -1)
                _URL = _URL.Substring(0, _Position + _ApplicationPath.Length);
    
            return _URL + "\\";
    
        }
