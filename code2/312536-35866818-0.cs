    CookieCollection Cookies = new CookieCollection();
                var web = new HtmlWeb();
                web.OverrideEncoding = Encoding.Default;
                web.UseCookies = true;
                web.PreRequest += (request) =>
                {
                    if (request.Method == "POST")
                    {
                        string payload = request.Address.Query;
                        byte[] buff = Encoding.UTF8.GetBytes(payload.ToCharArray());
                        request.ContentLength = buff.Length;
                        request.ContentType = "application/x-www-form-urlencoded";
                        System.IO.Stream reqStream = request.GetRequestStream();
                        reqStream.Write(buff, 0, buff.Length);
                    }
    
                    request.CookieContainer.Add(Cookies);
    
                    return true;
                };
    
                web.PostResponse += (request, response) =>
                {
                    if (request.CookieContainer.Count > 0 || response.Cookies.Count > 0)
                    {
                        Cookies.Add(response.Cookies);
                    }
                };
    
                string baseUrl = "Your Website URL";
                string urlToHit = baseUrl + "?QueryString with Login Credentials";
                HtmlDocument doc = web.Load(urlToHit, "POST");
