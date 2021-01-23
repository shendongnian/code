         Test t2 = new Test();
         System.Xml.Serialization.XmlSerializer xs3 = new System.Xml.Serialization.XmlSerializer(typeof(Test));
         string mergedXml = MergeSerializedXml(group1, group2);
         using (System.IO.StringReader sr = new System.IO.StringReader(mergedXml))
         {
            t2 = (Test)xs3.Deserialize(sr);
         }
    ...
      static string MergeSerializedXml(string x1, string x2)
      {
         System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
         xd.LoadXml(x1);
         System.Xml.XmlReaderSettings xrs = new System.Xml.XmlReaderSettings();
         xrs.IgnoreWhitespace = true;
         using (System.Xml.XmlReader xr = System.Xml.XmlReader.Create(new System.IO.StringReader(x2), xrs))
         {
            while (xr.Read() && !xr.IsStartElement())
               ;
            xr.MoveToContent();
            xr.Read();
            System.Xml.XmlNode xn = xd.ChildNodes[1];
            do
            {
               xn.AppendChild(xd.ReadNode(xr));
            } while (xr.NodeType != System.Xml.XmlNodeType.EndElement);
         }
         return xd.OuterXml;
      }
