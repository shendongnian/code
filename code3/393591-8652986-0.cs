        public string GetIISPath()
        {
            string urlscheme = System.Web.HttpContext.Current.Request.Url.Scheme;
            string host = System.Web.HttpContext.Current.Request.Url.Host;
            int port = System.Web.HttpContext.Current.Request.Url.Port;         
            //Ignore Http Port
            if (port != 80)
                host = host + ":" + port;
            string vPath = urlscheme + "://" + host + "/";
            return vPath;
        }
