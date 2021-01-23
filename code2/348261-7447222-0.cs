        class Node
        {
            public string Name { get; set; }
            public List<Node> Child { get; private set; }
            public Node(string name)
            {
                Child = new List<Node>();
                Name = name;
            }
        }
        static void Main(string[] args)
        {
            var listItems = new List<string>();
            var root = new Node("Root");
            root.Child.Add(new Node("1"));
            root.Child.Add(new Node("3"));
            var node = new Node("4");
            var nd = new Node("5");
            nd.Child.Add(new Node("7"));
            node.Child.Add(nd);
            node.Child.Add(new Node("6"));
            root.Child.Add(node);
            GetNames(root, listItems);
            foreach (var listItem in listItems)
            {
                Console.WriteLine(listItem);
            }
        }
        static void GetNames(Node parent, List<string> result)
        {
            result.Add(parent.Name);
            foreach (var child in parent.Child)
            {
                GetNames(child, result);
            }
        }
