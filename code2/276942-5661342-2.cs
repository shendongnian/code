    private string getNext(TreeNode node)
    {
        if (node.FirstNode != null)
        {
            return node.FirstNode.Name;
        }
        else
        {
            if (node.NextNode != null)
            {
                return node.NextNode.Name;
            }
            else if (node.Parent.NextNode != null)
            {
                return node.Parent.NextNode.Name;
            }
        }
        return "";
    }
