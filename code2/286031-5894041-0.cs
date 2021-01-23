    public static String GetViaName(String search, String xml)
    {
      var doc = XDocument.Parse(xml);
    
      return (from c in doc.Descendants("key")
        where ((String)c.Attribute("name")).Equals(search)
        select (String)c.Element("value")).FirstOrDefault().Trim();
    }
