    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication108
    {
        class Program
        {
            static DataBase db = new DataBase();
            static void Main(string[] args)
            {
                string parentName = string.Empty;
                Tree root = new Tree();
                GetTreeRecursively(parentName, root);
            }
            static void GetTreeRecursively(string parentName, Tree parent )
            {
                foreach (ContentModel model in db.contentModel.Where(x => x.parentName == parentName))
                {
                    if (parent.children == null) parent.children = new List<Tree>();
                    Tree newChild = new Tree();
                    parent.children.Add(newChild);
                    newChild.url = model.url;
                    string name = model.name;
                    newChild.name = name;
                    GetTreeRecursively(name, newChild);
                }
            }
        }
        public class DataBase
        {
            public List<ContentModel> contentModel { get; set; }
        }
        public class ContentModel
        {
            public string parentName  { get;set;}
            public string url { get;set;}
            public string x  { get;set;}
            public string y { get;set;}
            public string z  { get;set;}
            public string name;
        }
        public class Tree
        {
            public string name { get; set; }
            public string url { get; set; }
            public List<Tree> children { get; set; }
        }
    }
