    using (StreamReader r = new StreamReader(xmlfilepath))
    {
        string xmlString = r.ReadToEnd();
        XmlSerializer ser = new XmlSerializer(typeof(DATAPACKET));
        using (TextReader reader = new StringReader(xmlString))
        {
            var marketingAllCardholder = (DATAPACKET)ser.Deserialize(reader);
            //add your logic here
        }
    }
