    // rename all child nodes within parent to "ChildX"
    private void RenameNodes(TreeNode parent)
    {
        for(int i = 0; i < parent.Nodes.Count; i++)
        {
            parent.Nodes[i].Text = "Child" + (i + 1).ToString();
        }
    }
