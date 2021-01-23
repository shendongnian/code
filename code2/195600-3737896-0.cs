        public static string HttpPOST(string url, string querystring)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded"; // or whatever - application/json, etc, etc
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            try
            {
                requestWriter.Write(querystring);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
