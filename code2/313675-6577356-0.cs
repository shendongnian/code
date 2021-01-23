            webBrowser.Navigate(someUrl);
            ...
            CookieContainer cookies = new CookieContainer();
            foreach (string cookie in webBrowser.Document.Cookie.Split(';'))
            {
                string name = cookie.Split('=')[0];
                string value = cookie.Substring(name.Length + 1);
                string path = "/";
                string domain = "yourdomain.com";
                cookies.Add(new Cookie(name.Trim(), value.Trim(), path, domain));
            }
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookies;
            ...
