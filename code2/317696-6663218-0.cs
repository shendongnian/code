    TreeNode node = GetNode();
    TreeView view = (TreeView)node.GetType().
        GetProperty("Owner", 
            System.Reflection.BindingFlags.Instance | 
            System.Reflection.BindingFlags.NonPublic).GetValue(node, null);
