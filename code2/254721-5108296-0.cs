    HashSet<string> attributeNames = new HashSet<string>();
    
    xmlReader = listItem.CreateNavigator().ReadSubtree();
    
    while (xmlReader.Read())
    {
      if (xmlReader.NodeType == XmlNodeType.Element
        && xmlReader.Name == "rs:data")
      {  
        if (xmlReader.HasAttributes)
        {
          int attributeCount = xmlReader.AttributeCount;
          for (int i = 0; i < attributeCount; i++)
          {
            xmlReader.MoveToAttribute(i);
            attributeNames.Add(xmlReader.Name);
          }
        }
      }
    }
    
