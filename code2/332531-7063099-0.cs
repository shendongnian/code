    public class Node
        {
            string key;
            List<Node> children;
    
            public Node(string key)
            {
                this.key = key;
                children = new List<Node>();
            }
    
            public string Key { get { return key; } }
            public List<Node> Children { get { return children; } }
    
            public Node Find(Func<Node, bool> myFunc)
            {
                foreach (Node node in Children)
                {
                    if (myFunc(node))
                    {
                        return node;
                    }
                    else 
                    {
                        Node test = node.Find(myFunc);
                        if (test != null)
                            return test;
                    }
                }
    
                return null;
            }
        }
