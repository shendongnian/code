    //Add parent
    treeView.Nodes.Add(parentNode);
    //Loop through every child
    foreach(TreeNode childNode in parentNode.Nodes)
    {
        int index = 0;
        //Calculate childNode's children
        foreach (TreeNode node in loopNode.Nodes)
        {
            index++;
        }
        string node;
        //If index is 0, dont change text.
        if (index != 0) node = childNode.Text + " (" + index + ")";
        else node = childNode.Text;
        parentNode.Nodes.Add(childNode);
    }
    
