    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication139
    {
        class Program
        {
            static List<Step> steps = new List<Step>();
            static void Main(string[] args)
            {
                Tree root = new Tree();
                int rootId = 0;
                GetRecursive(rootId, root);
            }
            static void GetRecursive(int parentId, Tree parent)
            {
                foreach(Step step in steps.Where(x => x.id == parentId))
                {
                    parent.step = step;
                    if (parent.children == null) parent.children = new List<Tree>();
                    Tree child = new Tree();
                    parent.children.Add(child);
                    GetRecursive(step.id, child);
                }
            }
        }
        public class Step
        {
           public int id { get;set;}
           public string name { get;set;}
           public int parendId { get; set; }
        }
        public class Tree
        {
            public List<Tree> children { get; set; }
            public Step step { get; set; }
        }
    }
