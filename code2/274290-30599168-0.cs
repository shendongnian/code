    class WebPage
    {
        public static string Get(string uri)
        {
            string results = "N/A";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                results = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return results;
        }
    }
