    //Link this to the AfterCheck property
    private void treeViewCheckedChange(Object sender, TreeViewEventArgs e)
    {
        TreeNode node = (TreeNode)e.Node;
        checkedNodes(node);
    }
    
    //Recursive method checks child, and then calls itself
    private void checkedNodes(TreeNode parent)
    {
        foreach (TreeNode child in parent.Nodes)
        {
            child.Checked = parent.Checked;
            checkedNodes(child);
        }
    }
