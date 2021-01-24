    private void AddNodes()
    {
        advancedTreeView1.Nodes.Clear();
        for (int i = 0; i < numberOfRoots; i++)
        {
            TreeNode subnode = advancedTreeView1.Nodes.Add("New Node " + i);
            if (allRootsWithChilds.Checked || i < childCount)
            {
                for (int j = 0; j < depthLevel; j++)
                {
                    // Add a new child node and set subnode to the new node we just added
                    subnode = subnode.Nodes.Add(subnode.Text);
                }
            }
        }
    }
