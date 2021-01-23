    protected void Populate(TreeNode parentNode, DirectoryInfo directory)
    {
        foreach (DirectoryInfo dir in directory.GetDirectories())
        {
            TreeNode node = parentNode.Nodes[dir.Name] 
                ?? parentNode.Nodes.Add(dir.Name, dir.Name);
            node.Tag = dir;
            // node.ContextMenuStrip = cmenu;
            Populate(node, dir);
        }
    }
