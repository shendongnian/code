    internal string Get(string uri)
    {
        using (WebResponse wr = WebRequest.Create(uri).GetResponse())
        {
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
