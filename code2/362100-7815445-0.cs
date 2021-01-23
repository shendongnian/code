    List<string> attributes = new List<string>();
    XmlNodeList elemList = doc.GetElementsByTagName("Element");
    for (int i = 0; i < elemList.Count; i++)
    {   
         attributes.Add(elemList[i].Attributes["attribute"].Value);
    }  
