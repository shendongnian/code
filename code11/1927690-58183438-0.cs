    private void UncheckNodesExcept(TreeNode root, TreeNode except)
    {
        // Clear checkbox unless it is the one we don't want to clear
        if(root != except)
        {
            root.Checked = false;
        }
        // Recurse over childs
        foreach(TreeNode child in root.Nodes)
        {
            UncheckNodesExcept(child, except);
        }
    }
    private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
    {
        TreeView treeView = sender as TreeView;
        // Only if action was triggered by user
        if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
        {
            foreach(TreeNode node in treeView.Nodes)
            {
                UncheckNodesExcept(node, e.Node);
            }
        }
    }
