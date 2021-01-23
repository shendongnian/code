    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    ...
    public void Append(){
        XDocument xmldoc = XDocument.Load(@"yourXMLFile.xml"));
        XElement parentXElement = xmldoc.XPathSelectElement("yourRoot");
        XElement newXElement = new XElement("test", "abc");
    
        //append element
        parentXElement.Add(newXElement);
    
        xmldoc.Save(@"yourXMLFile.xml"));
      }
    
