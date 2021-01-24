        class Node
        {
            public int Value { get; set; }
            public Dictionary<string, Node> Children { get; set; }
            // The indexer indexes into the child dictionary.
            public Node this[string key] => Children[key];
        }
