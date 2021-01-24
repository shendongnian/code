    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
               string[] paths = new string[] {
                "ROOT!ZZZ!AAA!EEE!15712",
                "ROOT!ZZZ!AAA!EEE!15722",
                "ROOT!ZZZ!AAA!EEE!13891"};
                List<List<string>> inputData = paths.Select(x => x.Split(new char[] {'!'}).ToList()).ToList();
                Node root = new Node();
                Node.ParseTree(root, inputData);
            }
        }
        public class Node
        {
            public string name { get; set; }
            public List<Node> children { get; set; }
            public static void ParseTree(Node parent, List<List<string>> inputData)
            {
                parent.name = inputData.First().FirstOrDefault();
                var groups = inputData.Select(x => x.Skip(1)).GroupBy(x => x.Take(1).FirstOrDefault());
                foreach (var group in groups)
                {
                    if (group.Key != null)
                    {
                        if (parent.children == null) parent.children = new List<Node>();
                        Node newNode = new Node();
                        parent.children.Add(newNode);
                        ParseTree(newNode, group.Select(x => x.Select(y => y).ToList()).ToList());
                    }
                }
            }
        }
    }
