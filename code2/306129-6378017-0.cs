            //this only has login/password info, you may need other parameters to trigger the appropriate action:
            const string Parameters = "Login1$username=pfadmin&Login1$Password=password";
            System.Net.HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create("http://[WebApp]/Login.aspx");
            req.Method = "GET";
            req.CookieContainer = new CookieContainer();
            System.Net.HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //Create POST request and transfer session cookies from initial request
            req = (HttpWebRequest)System.Net.WebRequest.Create("http://localhost/AdminWeb/Login.aspx");
            req.CookieContainer = new CookieContainer();
            foreach (Cookie c in resp.Cookies)
            {
                req.CookieContainer.Add(c);
            }
            req.ContentType = "application/x-www-form-urlencoded";
            //...continue on with your form POST
