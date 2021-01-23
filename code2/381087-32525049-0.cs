    //you need to have 4 methods for it and call two of them...
    //code where treeview needs to save and restore
    var expState = GetAllExpandedNodesList(TreeView);
                        TreeView.Nodes.Clear();
                        //do something else...                    
    RestoreTreeViewState(TreeView, expState);
    //end of treeview save/restore section
    
    
            private static void UpdateExpandedList(ref List<string> expNodeList, TreeNode node)
            {
                if (node.IsExpanded) expNodeList.Add(node.FullPath);
                foreach (TreeNode n in node.Nodes)
                {
                    if (n.IsExpanded) UpdateExpandedList(ref expNodeList, n);
                }
            } 
    
            private static List<string> GetAllExpandedNodesList(TreeView tree)
            {
                var expandedNodesList = new List<string>();
    
                foreach (TreeNode node in tree.Nodes)
                {
                    UpdateExpandedList(ref expandedNodesList, node);
                }
                return expandedNodesList;
            }
    
    
            private static void ExpandNodes(TreeNode node, string nodeFullPath)
            {
                if (node.FullPath == nodeFullPath) node.Expand();
                foreach (TreeNode n  in node.Nodes)
                {
                    if (n.Nodes.Count >0) ExpandNodes(n, nodeFullPath); 
                }
            }
    
            private static void RestoreTreeViewState(TreeView tree, List<string> expandedState)
            {
                foreach (TreeNode node in tree.Nodes)
                {
                    foreach (var state in expandedState)
                    {
                        ExpandNodes(node, state);
                    }
                }
            }
