    System.IO.FileInfo[] aryFi = di.GetFiles("*.xml");
    
    
    foreach (System.IO.FileInfo fi in aryFi) {
     
     System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
     xmlDocument.Load(fi.FullName);
    
     XmlNode refelem = xmlDocument.LastChild;
     XmlNode newElem = xmlDocument.CreateNode("element", "something", "");
     newElem.InnerText = "sometext";
     xmlDocument.InsertAfter(newElem, refelem);
    }
