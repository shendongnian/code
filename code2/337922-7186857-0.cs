    foreach (XmlNode xNode in nodeListName)
    {
        if (xNode.ParentNode.Attributes.ItemOf["split"] != null)
        {
             parentSplit = xNode.ParentNode.Attributes["split"].Value;
        }
    }
