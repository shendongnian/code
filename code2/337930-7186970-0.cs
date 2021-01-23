    foreach (XmlNode xNode in nodeListName)
    {
      if (xNode.ParentNode.Attributes["split"] != null)
      {
         parentSplit = xNode.ParentNode.Attributes["split"].Value;
      }
    }
