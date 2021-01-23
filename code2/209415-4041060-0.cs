    public class Root
    {
        //Private and not exposed in a IList property = Encapsulation
        private List<Node> _nodes = new List<Node>(); 
    
        public void Visit(Action<Node> visitor)
        {
            // Controlled enumeration, can for instance handle exceptions in here.
            foreach (var item in _nodes)
            {
                visitor(node);
            }
        }
    }
    // usage
    root.Visit(node => Console.WriteLine(node));
