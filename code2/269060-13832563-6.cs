     private void IdentifyParentNodes()
    {
        SortedList<string, MyTreeNode> newParentNodes = new SortedList<string,MyTreeNode>();
        Dictionary<string, string> parents = new Dictionary<string, string>();
        foreach (MyTreeNode oParent in MyTreeDataSource.Values)
        {
            if (!parents.ContainsValue(oParent.ParentId))
            {
                parents.Add(oParent.ParentId + "." + oParent.ChildId, oParent.ParentId);
                newParentNodes.Add(oParent.ParentId + "." + oParent.ChildId, oParent);
            }
        }
        this._parentNodes = newParentNodes;
    }
