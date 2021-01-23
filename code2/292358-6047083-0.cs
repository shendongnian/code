    using System.Xml.Linq
    
    // [...]
    // Load the XML, either from a string or from an url
    var doc = XDocument.Parse(xmlString);
    
    // or
    var doc = XDocument.Load(new Uri(@"C:\myFile.xml"));
    
    var result = String.Empty;
    
    foreach (var el in doc.Descendants())
    {
       // do something with it and format the data to your liking... e.g.
       result += FormatElement(el);
    }
    
    // or more compact
    doc.Descendants().ToList().ForEach(el => result += FormatElement(el));
    
    // [...]
    
    private string FormatElement(XElement el)
    {
       return String.Format("{0}: {1}", el.Name, el.Value);
    }
