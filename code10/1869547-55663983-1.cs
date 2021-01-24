    public class Node
        {
            public List<Node> Children { get; set; } = new List<Node>();
            private bool _modified = false;
            public bool HasBeenModified
            {
                get => _modified || Children.Any(c => c.HasBeenModified);
                set => _modified = value;
            }
        }
