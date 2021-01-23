    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Tree
    {
        class Node {
            private List<Node> _kids = new List<Node>();
            public string Name { get; set; }
            public List<Node> Children { get { return _kids; } }
            public void Add(Node child) { _kids.Add(child); }
            public override string ToString() { return Name; }
        }
        class Program
        {
            Node _root;
            static void Main(string[] args) {
                new Program().Run();
                Console.Write("Press any key ...");
                Console.ReadKey();
            }
            Program() {
                _root = GenerateTree();
            }
            static Node GenerateTree()
            {
                // Gen0
                Node root = new Node() { Name = "Great-grandpa Jimmy Joe Jim-Bob John Keith Luke Duke" };
                // Add Gen1 to Gen0
                root.Add(new Node() { Name = "GrandUncle Joe Duke" });
                Node grandDad = new Node() { Name = "Granddad Jimmy Duke" };
                root.Add(grandDad);
                // Add Gen2 to Gen1
                grandDad.Add(new Node() { Name = "Uncle Jim" });
                grandDad.Add(new Node() { Name = "Uncle Bob" });
                Node dad = new Node() { Name = "Dad John" };
                grandDad.Add(dad);
                // Add Gen3 to Gen2
                dad.Add(new Node() { Name = "Brother Luke" });
                dad.Add(new Node() { Name = "Keith" });
                return root;
            }
            void Run() {
                Console.WriteLine("My Great-granddad is: " + Find("Keith", 3));
                Console.WriteLine("My granddad is: " + Find("Keith", 2));
                Console.WriteLine("My dad is: " + Find("Keith", 1));
                Console.WriteLine();
                Console.WriteLine("Brother Luke's Dad is: " + Find("Brother Luke", 1));
                Console.WriteLine("Uncle Bob's dad is: " + Find("Uncle Bob", 1));
                Console.WriteLine("Uncle Jim's granddad is: " + Find("Uncle Jim", 2));
                Console.WriteLine();
                Console.WriteLine("Lunil's mom is: " + Find("Lunil", 1));
                Console.WriteLine();
            }
            string Find(string targetName, int anticedentLevel) {
                Node n = Find(_root, targetName, ref anticedentLevel);
                return n!=null ? n.ToString() : "#NOT_FOUND#";
            }
            private static Node Find(Node node, string targetName, ref int ancenstorCount) {
                if ( node == null )
                    return null;
                if ( ancenstorCount == 0 ) // we've already found the right level to return
                    return node;
                if ( node.Name == targetName )
                    return node;
                foreach ( Node child in node.Children ) {
                    var found = Find(child, targetName, ref ancenstorCount);
                    if ( found != null ) {
                        if ( ancenstorCount == 0 )
                            return found;
                        --ancenstorCount;
                        return node; // return any non-null 
                    }
                }
                return null;
            }
        }
    }
