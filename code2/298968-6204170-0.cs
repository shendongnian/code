    void MoveNodeUp(TreeNode node)
    {
      TreeNode parentNode = node.Parent;
      int originalIndex = node.Index;
      if (node.Index == 0) return;
      TreeNode ClonedNode = (TreeNode)node.Clone();
      node.Remove();
      parentNode.Nodes.Insert(originalIndex - 1, ClonedNode);
      parentNode.TreeView.SelectedNode = ClonedNode;
      }
