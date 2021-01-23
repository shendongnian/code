    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.w3schools.com/xml/note.xml");
    webRequest.Proxy = WebRequest.DefaultWebProxy;
    using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
    {
        using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
        {
            XDocument document = XDocument.Load(new System.IO.StringReader(sr.ReadToEnd()));
            string xml = document.Root.ToString();
        }
    } 
