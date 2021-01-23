    private static System.Xml.XmlDocument GetDocumentStream(string xmlAddress)
    {
        System.Xml.XmlDocument document;
        byte[] xmlBlob = new System.Net.WebClient().DownloadData(xmlAddress);
        using (System.IO.MemoryStream temp = new System.IO.MemoryStream(xmlBlob))
        {
            document = new System.Xml.XmlDocument();
            document.Load(temp);
        }
        return document;
    }
