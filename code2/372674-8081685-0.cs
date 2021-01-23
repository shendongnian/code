    ResetChildTreeViews(this); // reset all treeviews within a form
    //...
    static void ResetChildTreeViews(Control container) {
        foreach(Control ctrl in container.Controls) {
            if(ctrl is TreeView)
                ResetTreeViewColors(ctrl as TreeView);
            else ResetChildTreeViews(ctrl);
        }
    }
    static void ResetTreeViewColors(TreeView treeView) {
        foreach(TreeNode node in treeView.Nodes)
            ResetTreeNodeColors(node);
    }
    static void ResetTreeNodeColors(TreeNode node) {
        node.BackColor = Color.White;
        node.ForeColor = Color.Black;
        foreach(TreeNode childNode in node.Nodes) 
            ResetTreeNodeColors(childNode);
    }
