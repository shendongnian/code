    public static XmlNode CreateXPath(XmlDocument doc, string xpath)
    {
        XmlNode node = doc;
        foreach (string part in xpath.Substring(1).Split('/'))
        {
            XmlNodeList nodes = node.SelectNodes(part);
            if (nodes.Count > 1) throw new ApplicationException("Xpath '" + xpath + "' was not found multiple times!");
            else if (nodes.Count == 1) { node = nodes[0]; continue; }
            if (part.StartsWith("@"))
            {
                var anode = doc.CreateAttribute(part.Substring(1));
                node.Attributes.Append(anode);
                node = anode;
            }
            else
            {
                string elName, attrib = null;
                if (part.Contains("["))
                {
                    part.SplitOnce("[", out elName, out attrib);
                    if (!attrib.EndsWith("]")) throw new ApplicationException("Unsupported XPath (missing ]): " + part);
                    attrib = attrib.Substring(0, attrib.Length - 1);
                }
                else elName = part;
                XmlNode next = doc.CreateElement(elName);
                node.AppendChild(next);
                node = next;
                if (attrib != null)
                {
                    if (!attrib.StartsWith("@"))
                    {
                        attrib = " Id='" + attrib + "'";
                    }
                    string name, value;
                    attrib.Substring(1).SplitOnce("='", out name, out value);
                    if (string.IsNullOrEmpty(value) || !value.EndsWith("'")) throw new ApplicationException("Unsupported XPath attrib: " + part);
                    value = value.Substring(0, value.Length - 1);
                    var anode = doc.CreateAttribute(name);
                    anode.Value = value;
                    node.Attributes.Append(anode);
                }
            }
        }
        return node;
    }
