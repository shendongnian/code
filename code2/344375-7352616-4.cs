    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.w3schools.com/xml/note.xml");
    webRequest.Proxy = WebRequest.DefaultWebProxy;
    using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
    {
        using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
        {
            XDocument document = XDocument.Load(new StringReader(streamReader.ReadToEnd()));
            string xml = document.Root.ToString();
            MessageBox.Show(xml);
        }
    } 
