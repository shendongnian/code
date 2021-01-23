       public string GetXMLAsString(XmlDocument myxml)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                   myxml.WriteTo(xmlTextWriter);
                   return stringWriter.ToString();
                }
    
            }    
    }
