    void ParseXmlString(string p_xmlString)
    {
       using (var stringReader = new StringReader(p_xmlString))
       using (var xmlReader = XmlReader.Create(stringReader))
       {
          while (xmlReader.Read())
          {
             // etc.
          }
       }
    }
