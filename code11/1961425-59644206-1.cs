    using (StreamReader r = new StreamReader(xmlFile))
    {
        string xmlString = r.ReadToEnd();
    
        XmlSerializer ser = new XmlSerializer(typeof(Reports));
    
        using (TextReader reader = new StringReader(xmlString))
        {
            var result = (Reports)ser.Deserialize(reader);
                       
        }
    }
