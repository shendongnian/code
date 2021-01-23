    private TreeListNode GetNodeByName(TreeListNodes prmNodes, String prmName)
    {
       foreach (TreeListNode node in prmNodes)
       {
          // Assume the data is present in column 0.
          if (node[0].ToString().Contains(prmName, StringComparison.CurrentCultureIgnoreCase))
             return node;
    
          TreeListNode foundNode = GetNodeByName(node.Nodes, prmName);
    
          if (foundNode != null)
             return foundNode;
       }
       return null;
    }
    //---------------------------------------------------------------------------
