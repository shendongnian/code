            webRequest_ = (HttpWebRequest)HttpWebRequest.Create(rparams.URL);
            webRequest_.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            webRequest_.Method = "POST";
            webRequest_.ContentType = "application/x-www-form-urlencoded";
            webRequest_.CookieContainer = cookieJar;
            
            var parameters = new StringBuilder();
            
            foreach (var key in rparams.Params)
            {
                parameters.AppendFormat("{0}={1}&",HttpUtility.UrlEncode(key.ToString()),
                    HttpUtility.UrlEncode(rparams.Params[key.ToString()]));
            }
            parameters.Length -= 1;
            using (var writer = new StreamWriter(webRequest_.GetRequestStream()))
            {
                writer.Write(parameters.ToString());
            }
            string html = string.Empty;
            using (response = webRequest_.GetResponse())
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    html = streamReader.ReadToEnd();
                    
                }
            }
