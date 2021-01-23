    TreeNode node = GetNode();
    TreeView view = 
        (TreeView) node.GetType().
            GetProperty("Owner", BindingFlags.Instance | BindingFlags.NonPublic).
                GetValue(node, null);
