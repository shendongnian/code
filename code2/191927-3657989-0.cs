    public class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }
        public int Id;
     
        public int ParentId;
        public List<Node> Children;
        public Node Parent;
        public static Node Deserialize(XmlElement xNode)
        {
            Node n = new Node();
            XmlElement xId = xNode.SelectSingleNode("id") as XmlElement;
            n.Id = int.Parse(xId.InnerText);
            XmlElement xParent = xNode.SelectSingleNode("parent") as XmlElement;
            n.ParentId = int.Parse(xParent.InnerText);
            return n;
        }
        public void AddChild(Node child)
        {
            Children.Add(child);
            child.Parent = this;
        }
        public void Serialize(XmlElement xParent)
        {
            XmlElement xNode = xParent.OwnerDocument.CreateElement("node");
            XmlElement xId = xParent.OwnerDocument.CreateElement("id");
            xId.InnerText = Id.ToString();
            xNode.AppendChild(xId);
            XmlElement xParentId = xParent.OwnerDocument.CreateElement("parent");
            xParentId.InnerText = ParentId.ToString();
            xNode.AppendChild(xParentId);
            foreach (Node child in Children)
                child.Serialize(xNode);
            xParent.AppendChild(xNode);
        }
    }
    public static XmlDocument DeserializeAndReserialize(XmlDocument flatDoc)
    {
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        foreach (XmlElement x in flatDoc.SelectNodes("//node"))
        {
            Node n = Node.Deserialize(x);
            nodes[n.Id] = n;
        }
        // at the end, retrieve parents for each node
        foreach (Node n in nodes.Values)
        {
            Node parent;
            if (nodes.TryGetValue(n.ParentId, out parent))
            {
               parent.AddChild(n);
            }
        }
        XmlDocument orderedDoc = new XmlDocument();
        XmlElement root = orderedDoc.CreateElement("root");
        orderedDoc.AppendChild(root);
        XmlElement xnodes = orderedDoc.CreateElement("nodes");
        foreach (Node n in nodes.Values)
        {
            if (n.Parent == null)
                n.Serialize(xnodes);
        }
        root.AppendChild(xnodes);
        return orderedDoc;
    }
