    private void AddNodes()
    {
        advancedTreeView1.Nodes.Clear();
        for (int i = 0; i < numberOfRoots; i++)
        {
            advancedTreeView1.Nodes.Add("New Node " + i);                
            if (allRootsWithChilds.Checked || i < childsnum)
            {
                TreeNode subnode = advancedTreeView1.Nodes[i];
                for (int j = 0; j < leveldepth; j++)
                {
                    // Add a new node to this subnode
                    subnode.Nodes.Add("New Node " + j);
                    // Set subnode to the new node we just added
                    subnode = subnode.Nodes[0];
                }
            }
        }
    }
