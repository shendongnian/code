    private SortedList<string, MyTreeNode> GetChildren(string parentId)
    {
        SortedList<string, MyTreeNode> childNodes = new SortedList<string, MyTreeNode>();
        foreach (MyTreeNode node in this.MyTreeDataSource.Values)
        {
            if (node.ParentId == parentId)
            {
                childNodes.Add(node.ParentId + node.ChildId, node);
            }
        }
        return childNodes;
    }
