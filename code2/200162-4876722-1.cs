    //load the url in to query url
    TextReader = new XmlTextReader(QueryUrl);
    TextReader.ReadInnerXml();
    // Create a new XmlDocument  
    XmlDocument doc = new XmlDocument();
    // Load data  
    doc.Load(QueryUrl);
    // Get forecast with XPath  
    XmlNodeList nodes = doc.SelectNodes(xpathtitle);
    if (nodes != null)
    {
        foreach (XmlNode titlenode in nodes)
        {
            if (titlenode != null)
            {
                foreach (XmlNode child in titlenode.ChildNodes)
                {
                    if (child != null)
                    {
                        // your code here..
                    }
                }
            }
         }
    }
