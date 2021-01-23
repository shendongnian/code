    public static class TreeViewExtensions
        {
            public static void LoadXml(this TreeView treeview, XmlDocument doc)
            {
                treeview.Nodes.Clear();
    
                RecursiveImport(treeview.Nodes, doc.ChildNodes);
            }
    
            private static void RecursiveImport(TreeNodeCollection tvNodes, XmlNodeList xmlNodes)
            {
                TreeNode tvNode;
    
                foreach (XmlNode xmlNode in xmlNodes)
                {
                    tvNode = new TreeNode(xmlNode.Name);
    
                    if (xmlNode.ChildNodes.Count > 0)
                        RecursiveImport(tvNode.Nodes, xmlNode.ChildNodes);
    
                    tvNodes.Add(tvNode);
                }
            }
        }
