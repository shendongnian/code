    foreach (XmlNode xNode in nodeListName)
    {
      XmlElement xEle = xNode as XmlElement;
      if(xEle == null) { continue; }
    
      if(xEle.HasAttribute("split"))
      {
         parentSplit = xNode.ParentNode.Attributes["split"].Value;
      }
    }
