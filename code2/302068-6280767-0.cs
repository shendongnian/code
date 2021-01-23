    TreeNode rootNode = TreeView.Nodes.Cast<TreeNode>().ToList().Find(n => n.Text.Equals("Root"));
    if (rootNode != null)
    {
        rootNode.Nodes.Add("child2");
    }
