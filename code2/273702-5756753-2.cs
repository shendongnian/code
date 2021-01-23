    List<string> values = new List<string>;
    
    //Called by a button click or another control
    private void getTreeValues(Object sender, EventArgs e)
    {
        foreach (string node in treeView.Nodes)
        {
            TreeNode child = (TreeNode)child;
            values.Add(node)
            getNodeValues(child);
        }
        foreach (string value in values)
        {
            Console.WriteLine(value + "\n");
        }
    }
    
    //Recursive method which finds all children of parent node.
    private void getNodeValues(TreeNode parent)
    {
        foreach (string child in parent.Nodes)
        {
            TreeNode node = (TreeNode)child;
            values.Add(child);
            if (nodes.Nodes.Count != 0) getNodeValues(child);
        }
    }
 
