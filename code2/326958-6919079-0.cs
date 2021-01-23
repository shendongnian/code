     HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("wwww.someurl.com");
            httpWebRequest.Timeout = 10000; // 10 second timeout
            using(HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using(Stream responseStream = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            var htmlstring = reader.ReadToEnd();
                             HtmlDocument doc = new HtmlDocument();
                             doc.Load(htmlstring);
                        }
                    }
                 
                }
            }
