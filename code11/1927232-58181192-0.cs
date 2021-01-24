    XDocument doc = XDocument.Parse(testXML1);
    XNamespace ns = doc.Root.GetDefaultNamespace();
    string ExternalCustomerId="";    
    string CustomerId=""; 
    foreach (XElement element in doc.Descendants(ns + "ExternalCustomerId"))
     {
       ExternalCustomerId = element.Value;
     }
     foreach (XElement element in doc.Descendants(ns + "CustomerId"))
     {
       CustomerId = element.Value;
     }
