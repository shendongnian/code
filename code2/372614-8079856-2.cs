    public IList<int> GetNodePathIndexes(TreeNode node)
    {
        List<int> indexes = new List<int>();
        TreeNode currentNode = node;
        while (currentNode != null)
        {
            TreeNode parentNode = currentNode.Parent;
            if (parentNode != null)
                indexes.Add(parentNode.Nodes.IndexOf(currentNode));
            else
                indexes.Add(currentNode.TreeView.Nodes.IndexOf(currentNode));
            currentNode = parentNode;
        }
        indexes.Reverse();
        return indexes;
    }
    
