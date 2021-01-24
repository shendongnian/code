    public enum NodeType
    {
        ANDGate,
        ORGate,
        Event
    }
    public class Node
    {
        public string Name { get; }
        public NodeType Type { get; }
        public List<Node> Children { get; }
        public Node(string name, NodeType type, params Node[] children)
        {
            this.Name = name;
            this.Type = type;
            //This is to check that al leaves are events
            if (children.Length == 0 && type != NodeType.Event)
                throw new Exception();
            this.Children = children.ToList();
        }
        public List<string> GetMinSet()
        {
            if (Type == NodeType.Event)
                return new List<string>() { Name };
            var min = new List<string>();
            bool firstMinSetted = false;
            if (Type == NodeType.ANDGate)
            {
                foreach (var item in Children)
                {
                    min.AddRange(item.GetMinSet());
                }
            }
            else
            {
                foreach (var item in Children)
                {
                    var temp = item.GetMinSet();
                    if (firstMinSetted)
                        min = temp.Count < min.Count ? temp : min;
                    else
                        min = temp;
                    firstMinSetted = true;
                }
            }
            return min;
        }        
    }
~~~
