    public void Copy(TreeView treeview1, TreeView treeview2)
    {
        TreeNode newTn;
        foreach (TreeNode tn in treeview1.Nodes)
        {
            newTn = tn;
            CopyChilds(newTn, tn);
            treeview2.Nodes.Add(tn);
        }
    }
    public void CopyChilds(TreeNode parent, TreeNode willCopied)
    {
        foreach (TreeNode tn in willCopied.ChildNodes)
            parent.ChildNodes.Add(tn);
    }
