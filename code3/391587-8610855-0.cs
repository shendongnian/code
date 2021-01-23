            webRequest_ = (HttpWebRequest)HttpWebRequest.Create(rparams.URL);
            webRequest_.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            CookieContainer cookieJar = new CookieContainer();
            webRequest_.CookieContainer = cookieJar;
            string html = string.Empty;
            try
            {
                using (WebResponse response = webRequest_.GetResponse())
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        html = streamReader.ReadToEnd();
                        ParseLoginRequest(html, response,cookieJar);
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                        Console.WriteLine(html = streamReader.ReadToEnd());
                }
            }
