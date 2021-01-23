    public class Node
    {
        public string Name { get; set; }
        public ObservableCollection<Node> SubItems { get; set; }
        public SolidColorBrush ForegroundColor { get; set; }
        public Node(string name, Color foregroundColor, params Node[] items)
        {
            this.Name = name;
            this.SubItems = new ObservableCollection<Node>(items);
            this.ForegroundColor = new SolidColorBrush(foregroundColor);
        }
    }
