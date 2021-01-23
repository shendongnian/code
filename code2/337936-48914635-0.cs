    foreach (XmlNode xNode in nodeListName)
    {
        if(xNode.ParentNode.Attributes.GetNamedItem("split") != null )
        {
            if(xNode.ParentNode.Attributes["split"].Value != "")
            {
                parentSplit = xNode.ParentNode.Attributes["split"].Value;
            }
        }  
    }
