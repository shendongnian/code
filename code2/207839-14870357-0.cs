        var request = WebRequest.Create(url);
            request.Proxy = null;
            request.Timeout = Timeout.Infinite;
            string text = "";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }
            }
