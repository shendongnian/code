      XmlDocument doc = new XmlDocument();
      doc.LoadXml(xmlParam.Value.ToString());
      using (StreamWriter wIn = new StreamWriter(xmlFile, false))
      using (XmlTextWriter wr = new XmlTextWriter(wIn))
      {
        wr.Formatting = Formatting.Indented;
        doc.WriteTo(wr); 
      }
