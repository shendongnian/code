        XmlSerializableNewClass test2 = new XmlSerializableNewClass();
        
        System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
        settings.ConformanceLevel = System.Xml.ConformanceLevel.Fragment;
        settings.IgnoreWhitespace = true;
        settings.IgnoreComments = true;
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create("input.xml", settings);
        test2.ReadXml(reader);
        reader = System.Xml.XmlReader.Create("old.xml", settings);
        test2.ReadXml(reader);
