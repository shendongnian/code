     var XmlDoc = new XmlDocument();
     // setup the XML namespace manager
     XmlNamespaceManager mgr = new XmlNamespaceManager(XmlDoc.NameTable);
     // add the relevant namespaces to the XML namespace manager
     mgr.AddNamespace("ns", "http://DFISofft.com/SmartPayments/"); 
    
     XmlDoc.LoadXml(Resources.xmltest);
     // **USE** the XML anemspace in your XPath !!
     XmlElement NodePath = (XmlElement) XmlDoc.SelectSingleNode("/ns:Response");
    
      while (NodePath != null)
      {
        foreach (XmlNode Xml_Node in NodePath)
        {
          Console.WriteLine(Xml_Node.Name + " " + Xml_Node.InnerText);
        }
      }
