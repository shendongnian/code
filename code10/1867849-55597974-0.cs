    public static List<string> GetNodeInfo(XmlNode node)
    {
        if (node == null) return new List<string>();
        var nodes = new List<string>
        {
            node.NodeType == XmlNodeType.Text
                ? node.Value.TrimStart()
                : node.Name.TrimStart()
        };
        if (node.Attributes != null)
        {
            nodes.AddRange(node.Attributes.Cast<XmlAttribute>()
                .Select(attribute => $"{attribute.Name} {attribute.Value}\n"));
        }
        nodes.AddRange(node.ChildNodes.Cast<XmlNode>().SelectMany(GetNodeInfo));
        return nodes;
    }
