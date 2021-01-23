    public void Copy(TreeView treeview1, TreeView treeview2)
    {
        TreeNode newTn;
        foreach (TreeNode tn in treeview1.Nodes)
        {
            newTn = new TreeNode(tn.Text, tn.Value);
            CopyChilds(newTn, tn);
            treeview2.Nodes.Add(newTn);
        }
    }
    public void CopyChilds(TreeNode parent, TreeNode willCopied)
    {
        TreeNode newTn;
        foreach (TreeNode tn in willCopied.ChildNodes)
        {
            newTn = new TreeNode(tn.Text, tn.Value);
            parent.ChildNodes.Add(newTn);
        }
    } 
  
