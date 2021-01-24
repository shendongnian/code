    public class Node
    {
        public Node()
        {
            Nodes = new ObservableCollection<Node>();
        }
        public bool IsFolder { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
        public ObservableCollection<Node> Folders { get; set; }
        public void Add(Node node)
        {
            Nodes.Add(node);
            if (node.IsFolder)
                Folders.Add(node);
        }
        public void Remove(Node node)
        {
            Nodes.Remove(node);
            if (node.IsFolder)
                Folders.Remove(node);
        }
    }
