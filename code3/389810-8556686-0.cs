    using System.Linq;
    using System.Xml.Linq;
    // . . .
    string xml = @"<?xml version='1.0' encoding='utf-8' ?> ..."; 
    // . . . rest of XML string omitted for brevity . . . 
    // Read XML from string
    XDocument document = XDocument.Parse(xml);
    // Select the first matching 'param' element with the specified name
    XElement paramElement = 
        (from p in document.Descendants("param")
        let a = p.Attribute("name")
        where a != null && a.Value == "sz2ndItemNumber"
        select p).FirstOrDefault();
    if (paramElement != null)
    {
        // Get the inner text
        string text = paramElement.Value;
        // Set the inner text
        paramElement.Value = "Something Else";
        // Get the new XML document text
        string newXml = document.ToString();
        // . . .
    }
