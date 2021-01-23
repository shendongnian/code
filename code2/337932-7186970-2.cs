    foreach (XmlNode xNode in nodeListName)
    {
      XmlNode parent = xNode.ParentNode;
      if (parent.Attributes != null
         && parent.Attributes["split"] != null)
      {
         parentSplit = parent.Attributes["split"].Value;
      }
    }
