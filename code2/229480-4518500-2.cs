    Uri uri = new Uri(url); 
    System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri.AbsoluteUri);
            req.AllowAutoRedirect = true;
            req.MaximumAutomaticRedirections = 3;
            //req.UserAgent = _UserAgent; //"Mozilla/6.0 (MSIE 6.0; Windows NT 5.1; Searcharoo.NET)";
            req.KeepAlive = true;
            req.Timeout = _RequestTimeout * 1000; //prefRequestTimeout 
            // SIMONJONES http://codeproject.com/aspnet/spideroo.asp?msg=1421158#xx1421158xx
            req.CookieContainer = new System.Net.CookieContainer();
            req.CookieContainer.Add(_CookieContainer.GetCookies(uri));
