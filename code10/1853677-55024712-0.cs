    string uriStringList = (uriRoutePrefix);
            string inputJson = (new JavaScriptSerializer()).Serialize(requestList);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(uriStringList));
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
            using (Stream stream = httpRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream stream = httpResponse.GetResponseStream())
                {
                   string lblOutput = (new StreamReader(stream)).ReadToEnd();
                }
            }
 
