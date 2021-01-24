    public class Node
    {
            public Node()
            {
                Nodes = new ObservableCollection<Node>();
            }
        public bool IsFolder { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
        public IEnumerable<Node> Folders => Nodes.Where(n => n.IsFolder);
    }
