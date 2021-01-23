    TreeNode oMainNode = oYourTreeView.Nodes[0];
    PrintNodesRecursive(oMainNode);
    
    //CHANGED FUNCTION NAME TO PrintNodesRecursive
    public void PrintNodesRecursive(TreeNode oParentNode)
    {
      Console.WriteLine(oParentNode.Text);
    
      // Start recursion on all subnodes.
      foreach(TreeNode oSubNode in oParentNode.Nodes)
      {
        PrintNodesRecursive(oSubNode);
      }
    }
