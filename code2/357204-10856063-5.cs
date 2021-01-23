    protected void tree_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
            
            if (tree.CheckedNodes.Count > 0)
            {
                // Iterate through the CheckedNodes collection and display the selected nodes.
                foreach (TreeNode node in tree.CheckedNodes)
                {
                    Response.Write (node.Value + "<br />");
                    
                }
            }
    
            else
            {
                Response.Write("No items selected.");
    
            }
    
        }
