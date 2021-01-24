    static DataTable DataFromFile()
    {
        System.Xml.XmlTextReader reader =
        new System.Xml.XmlTextReader(@"C:\Data.xml");
        DataSet DataFromXML = new DataSet();
        DataFromXML.ReadXml(reader);
        
        // just return
        return DataFromXML.Tables[0];
    }
