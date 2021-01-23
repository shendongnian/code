    List<string> returnList = new List<string>();
    XmlNodeList node = xmlDocument.GetElementsByTagName("DebugUsersMail");
    XmlNodeList childNodes = node[0].ChildNodes;
    for(int i = 0; i < childNodes.Count; i++)
    {
       returnList.Add(childNodes[i].InnerText);
    }
    return returnList;
