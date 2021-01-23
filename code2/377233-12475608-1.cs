    public class DGMLWriter
    {
        public struct Graph
        {
            public Node[] Nodes;
            public Link[] Links;
        }
        public struct Node
        {
            [XmlAttribute]
            public string Id;
            [XmlAttribute]
            public string Label;
            public Node(string id, string label)
            {
                this.Id = id;
                this.Label = label;
            }
        }
        public struct Link
        {
            [XmlAttribute]
            public string Source;
            [XmlAttribute]
            public string Target;
            [XmlAttribute]
            public string Label;
            public Link(string source, string target, string label)
            {
                this.Source = source;
                this.Target = target;
                this.Label = label;
            }
        }
        public List<Node> Nodes { get; protected set; }
        public List<Link> Links { get; protected set; }
        public DGMLWriter()
        {
            Nodes = new List<Node>();
            Links = new List<Link>();
        }
        public void AddNode(Node n)
        {
            this.Nodes.Add(n);
        }
        public void AddLink(Link l)
        {
            this.Links.Add(l);
        }
        public void Serialize(string xmlpath)
        {
            Graph g = new Graph();
            g.Nodes = this.Nodes.ToArray();
            g.Links = this.Links.ToArray();
            XmlRootAttribute root = new XmlRootAttribute("DirectedGraph");
            root.Namespace = "http://schemas.microsoft.com/vs/2009/dgml";
            XmlSerializer serializer = new XmlSerializer(typeof(Graph), root);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(xmlpath, settings))
            {
                serializer.Serialize(xmlWriter, g);
            }
        }
    }
