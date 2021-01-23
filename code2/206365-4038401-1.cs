       private static string MakeTree()
        {
            List<Node> __myTree = new List<Node>();
            List<string> urlRecords = new List<string>();
            urlRecords.Add("home/image1");
            urlRecords.Add("home/image2");
            urlRecords.Add("IT/contact/map");
            urlRecords.Add("IT/contact/address");
            urlRecords.Add("IT/jobs");
            __myTree = ExtractNode(urlRecords);
            List<string> __roots = new List<string>();
            foreach(Node itm in __myTree)
            {
                if (itm.IsRoot)
                {
                    __roots.Add(itm.Child.ToString());
                }
            }
            string __trees = string.Empty;
            foreach (string roots in __roots)
            {
                __trees += GetChildren(roots, __myTree) + "<hr/>";
            }
            return __trees;
        }
        private static string GetChildren(string PRoot, List<Node> PList)
        {
            string __res = string.Empty;
            int __Idx = 0;
            foreach (Node x in PList)
            {
                if (x.Parent.Equals(PRoot))
                {
                    __Idx += 1;
                }
            }
            if (__Idx > 0)
            {
                string RootHeader = string.Empty;
                foreach (Node x in PList)
                {
                    if (x.IsRoot & PRoot == x.Child)
                    {
                        RootHeader = x.Child;
                    }
                }
                __res += RootHeader+ "<ul>\n";
                foreach (Node itm in PList)
                {
                    if (itm.Parent.Equals(PRoot))
                    {
                        __res += string.Format("<ul><li>{0}{1}</li></ul>\n", itm.Child, GetChildren(itm.Child, PList));
                    }
                }
                __res += "</ul>\n";
                return __res;
            }
            return string.Empty;
        }
        private static List<Node> ExtractNode(List<string> Urls)
        {
            List<Node> __NodeList = new List<Node>();
            foreach (string itm in Urls)
            {
                string[] __arr = itm.Split('/');
                int __idx = -1;
                foreach (string node in __arr)
                {
                    __idx += 1;
                    if (__idx == 0)
                    {
                        Node __node = new Node(node, "");
                        if (!__NodeList.Exists(x => x.Child == __node.Child & x.Parent == __node.Parent))
                        {
                            __node.IsRoot = true;
                            __NodeList.Add(__node);    
                        }
                    }
                    else
                    {
                        Node __node = new Node(node, __arr[__idx - 1].ToString());
                        {
                            if (!__NodeList.Exists (x => x.Child == __node.Child & x.Parent == __node.Parent))
                            {
                                __NodeList.Add(__node);
                            }
                        }
                    }
                }
            }
            return __NodeList;
        }
