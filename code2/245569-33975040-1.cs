    public static LocationData GetLocation(string ip= "")
    {
        using (var client = new System.Net.WebClient())
        {
             XmlRootAttribute xRoot = new XmlRootAttribute();
             xRoot.ElementName = "Response";
             string downloadedString = client.DownloadString("http://freegeoip.net/xml/" + ip);
               XmlSerializer mySerializer = new XmlSerializer(typeof(LocationData), xRoot) ;
            using (XmlReader xmlReader = XmlReader.Create(new System.IO.StringReader(downloadedString)))
            {
                 return mySerializer.Deserialize(xmlReader)as LocationData;
            }
         }
    }
