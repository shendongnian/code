    declinedNode = entityNode.GetChildNode("link-entity", "link-entity[@name='xx_decline_{0}']".FormatWith(memberType));
    declinedNode.SetAttribute("name", "xx_decline_{0}".FormatWith(memberType));
    declinedNode.SetAttribute("from", "xx_parent_{0}id".FormatWith(memberType));
    declinedNode.SetAttribute("to", "{0}id".FormatWith(memberType));
    declinedNode.SetAttribute("link-type", "outer");
    declinedNode.SetAttribute("alias", "declined");
    var declinedDateNode = fetchXmlDoc.CreateNode(XmlNodeType.Element, "attribute", string.Empty);
    declinedDateNode .SetAttribute("name", "xx_declineddate");
    declinedNode.AppendChild(declinedDateNode);
