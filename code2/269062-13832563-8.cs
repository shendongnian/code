    private void RecursivelyBuildTree(MyTreeNode node)
    {
        int nodePosition = 0;
        _renderedTree.Append(FormatNode(MyTreeNodeType.Parent, node, 0));
        _renderedTree.Append(NodeContainer("open", node.ParentId));
    	foreach (MyTreeNode child in GetChildren(node.ParentId).Values)
        {
            nodePosition++;
            if (IsParent(child.ChildId))
            {
                RecursivelyBuildTree(child);
            }
            else
            {
                _renderedTree.Append(FormatNode(MyTreeNodeType.Leaf, child, nodePosition));
            }
        }
        _renderedTree.Append(NodeContainer("close", node.ParentId));
    }
