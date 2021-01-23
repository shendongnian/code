    XDocument xdoc = XDocument.Load("Testxml.xml");  
    // It might be that Control element is a bit deeper in XML document
    // hierarchy so if you was not able get it work please provide XML you are using
    string value = xdoc.Descendants("Control")
                      .Where(d => d.HasAttributes
                                  && d.Attribute("Visible") != null
                                  && !String.IsNullOrEmpty(d.Attribute("Visible").Value))
                      .Select(d => d.Attribute("Visible").Value)
                      .Single();
