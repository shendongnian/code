    public static TreeNode SearchAllTreeNodes(TreeNode rootNode, Func<TreeNode, bool> matchCriteria, string Value)
    {
      if (matchCriteria != null ) 
       {
          var result = matchCriteria(rootNode);
       }
    }
