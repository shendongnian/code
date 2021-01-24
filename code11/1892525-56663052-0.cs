     System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(bizobj.Message.BodyPart.GetOriginalDataStream());
            string output = xDoc.DocumentElement.InnerXml;
        byte[] byteArray = Encoding.ASCII.GetBytes(output);
        MemoryStream stream = new MemoryStream(byteArray);
        stream.Position = 0;
        bizobj.Message.BodyPart.Data = stream;
        
        return bizobj;
