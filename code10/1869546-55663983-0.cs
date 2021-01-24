    public class Node
        {
            public List<Node> Children { get; set; } = new List<Node>();
            private bool _modified = false;
            public bool HasBeenModified => _modified || Children.Any(c => c.HasBeenModified);
        }
