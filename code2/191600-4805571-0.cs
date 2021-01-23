    /// <summary>
    /// Prepares the XML Tree, to write short format tags, instead
    /// of an opening and a closing tag. This leads to shorter and
    /// particularly to valid XML files.
    /// </summary>
    protected static void Sto_XmlShortTags(XmlNode node)
    {
      // if there are children, make a recursive call
      if (node.ChildNodes.Count > 0)
      {
        foreach (XmlNode childNode in node.ChildNodes)
          Sto_XmlShortTags(childNode);
      }
      // if the node has no children, use the short format
      else
      {
        if (node is XmlElement)
          ((XmlElement)node).IsEmpty = true;
      }
    }
