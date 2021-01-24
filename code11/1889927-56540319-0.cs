        private object ProcessResponse(string xmlData)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/xml";
            httpWebRequest.Method = "POST";
            object result = null;
            if (!string.IsNullOrEmpty(xmlData))
            {
                byte[] data = Encoding.UTF8.GetBytes(xmlData);
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            return result;
        }
