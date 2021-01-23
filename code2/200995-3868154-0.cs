        string GetWebPageContent(string url)
        {
            //string result = string.Empty;
            HttpWebRequest request;
            const int bytesToGet = 1000;
            request = WebRequest.Create(url) as HttpWebRequest;
            var buffer = new char[bytesToGet];
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    sr.Read(buffer, 0, bytesToGet);
                }
            }
            return new string(buffer);
        }
