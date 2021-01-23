    TreeNode oMainNode = oYourTreeView.Nodes[0];
    PrintNodesRecursive(oMainNode);
    
    public void PrintNodesNodesRecursive(TreeNode oParentNode)
    {
      Console.WriteLine(oParentNode.Text);
    
      // Start recursion on all subnodes.
      forech(TreeNode oSubNode in oParentNode.Nodes)
      {
        PrintNodesRecursive(oParentNode);
      }
    }
