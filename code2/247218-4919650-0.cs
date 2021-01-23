        XmlSerializer xmlSerializer = new XmlSerializer(typeof(myobject));
        // load document
        XmlDocument doc = new XmlDocument();
        doc.Load(filename);
        // remove all comments
        XmlNodeList l = doc.SelectNodes("//comment()");
        foreach (XmlNode node in l) node.ParentNode.RemoveChild(node);
        // store to memory stream and rewind
        MemoryStream ms = new MemoryStream();
        doc.Save(ms);
        ms.Seek(0, SeekOrigin.Begin);
        // deserialize using clean xml
        xmlSerializer.Deserialize(XmlReader.Create(ms));
