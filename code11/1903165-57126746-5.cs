    public Node<string> CloneTextRecursive(TreeNode treeNode)
    {
        var node = new Node<string> { Value = treeNode.Text };
        foreach (TreeNode subTreeNode in treeNode.Nodes) {
            node.Children.Add(CloneTextRecursive(subTreeNode));
        }
        return node;
    }
