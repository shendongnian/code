    namespace MiniGraphLibrary
    {
        public class Node
        {
            private string _info;
            private List<Node> _children = new List<Node>();
    
            public Node(Node parent, string info)
            {     
                this._info = info;
                this.Parent = parent;
            }
    
            public Node Parent { get; set; }
    
            public void AddChild(Node node)
            {
                if (!this.DoesNodeContainChild(node))
                {
                    node.Parent = this;
                    _children.Add(node);
                }
            }
    
            public bool DoesNodeContainChild(Node child)
            {
                return _children.Contains(child);
            }
        }
    }
