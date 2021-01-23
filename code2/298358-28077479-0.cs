    string xmlstring =@"<tag>.....</tag>"; // holds xml tree to be appended
           XmlDocument xml2 = new XmlDocument();
            xml2.Load(@"path_of_main_xml");
            XmlDocument xml1 = new XmlDocument();
            xml1.Load(new StringReader(xmlString));
            // get the node you want to import which in this icase is string
            XmlNode elem = xml1.DocumentElement;
     // use importNode to import it
            XmlNode impnode = xml2.ImportNode(elem,true);
     // get the node list of all node of particular tag name
            XmlNodeList eNode = xml2.GetElementsByTagName("tag_name_of_parent");
            eNode[0].AppendChild(impnode); // append new node
    // write back the updates to same file
            XmlWriter writer = XmlWriter.Create(@"path_of_main_xml");
            xml2.Save(writer); 
