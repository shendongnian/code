    XmlDocument oldDoc = new XmlDocument();
    XmlDocument newXmlDoc = new XmlDocument();
    oldDoc.LoadXml("<Feedback><Officer>Officer</Officer><Answers>My text</Answers><Date>20190917</Date></Feedback>");
    
    XmlElement newRoot = newXmlDoc.CreateElement("feedback");
    newXmlDoc.AppendChild(newRoot);
    
    XmlNode root = newXmlDoc.DocumentElement;
    
    foreach (XmlNode node in oldDoc.FirstChild.ChildNodes)
    {
        XmlElement elem = newXmlDoc.CreateElement(node.Name);
        elem.InnerText = node.InnerText;
    
        //Add the node to the document.
        root.AppendChild(elem);
    }
    
    XmlTextWriter writer = new XmlTextWriter(Console.Out);
    writer.Formatting = Formatting.Indented;
    newXmlDoc.WriteTo(writer);
    writer.Flush();
    Console.WriteLine();
    Console.ReadLine();
