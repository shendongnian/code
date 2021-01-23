    string elementNameToFind = "myElement";
    XmlReader xmlReader = XmlReader.Create(@"myFile.xml");
    string foundElementContent = string.Empty;
    while (xmlReader.Read())
    {
       if(xmlReader.NodeType==XmlNodeType.Element &&
          xmlReader.Name == elementNameToFind)
       {
         foundElementContent=xmlReader.ReadInnerXml();
         break;
       }
    }
    xmlReader.Close();
