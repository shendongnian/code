    for (int i = 0; i < treeView1.Nodes.Count; i++)
    {
        for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
        {
            foreach (var item in myDictionaryReconstructed)
            {
                if ("TreeNode: " + item.Key == treeView1.Nodes[i].Nodes[j].ToString())
                {
                    treeView1.Nodes[i].Nodes[j].Nodes.Add(item.Value);
                    treeView1.ExpandAll();
                }
            } 
        } 
    }
