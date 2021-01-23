    public SyndicationFeed GetFeed(String url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        using (var response = request.GetResponse())
        using (var responseStream = response.GetResponseStream())
        {
            Debug.Assert(responseStream != null, "responseStream != null");
    
            var xmlReaderSettings = new XmlReaderSettings { IgnoreComments = true };
            using (XmlReader xmlReader = XmlReader.Create(responseStream, xmlReaderSettings))
            {
                var feed = SyndicationFeed.Load(xmlReader);
                return feed;
            }
        }
    }
