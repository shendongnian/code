    public static TreeNode SearchAllTreeNodes(TreeNode rootNode, string property, string value)
    {
      PropertyInfo propertyInfo = treeNode.GetType().GetProperty(property);
      if (propertyInfo.GetValue(treeNode, null).ToString() == value)
      {
        /* Do stuff */
      }
    }
    public static void Main(string[] args)
    {
      /* ... */
      SearchAllTreeNodes(someNode, "Tag", "foo");
    }
