    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    public class Root
    {
        public Root()
        {
            this.Children = new List<Node>();
        }
        public List<Node> Children { get; set; }
    }
    public class Node : Root
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Root()
            {
                Children =
                {
                    new Node()
                    {
                        Name = "A",
                        Children =
                        {
                            new Node() { Name = "1" },
                            new Node() { Name = "2" },
                        }
                    },
                    new Node()
                    {
                        Name = "B",
                        Children =
                        {
                            new Node() { Name = "1" },
                            new Node() { Name = "2" },
                        }
                    },
                }
            };
            var treeSerializer = new XmlSerializer(typeof(Root));
            using (var writer = new StringWriter())
            {
                treeSerializer.Serialize(writer, tree);
                Console.WriteLine(writer.ToString());
            }
        }
    }
