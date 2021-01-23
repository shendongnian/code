    public TreeNode GenerateCategoriesTree(DataTable dt) {
      var s = new Stack<TreeNodeAndId>();
      var categories = dt.AsEnumerable();
      var rootCategory = categories.Single(o => o.Field<int?>("parents_id") == null);
      var rootNode = new TreeNode(rootCategory["category_name"].ToString(), rootCategory["category_id"].ToString());
      s.Push(new TreeNodeAndId { Id = Convert.ToInt32(rootCategory["category_id"]), TreeNode = rootNode });
      while (s.Count > 0) {
        var node = s.Peek();
        var current = categories.FirstOrDefault(o => o.Field<int?>("parents_id") == node.Id);
        if (current == null) {
          s.Pop();
          continue;
        }
        var child = new TreeNode(current["category_name"].ToString(), current["category_id"].ToString());
        node.TreeNode.ChildNodes.Add(child);
        s.Push(new TreeNodeAndId { Id = Convert.ToInt32(current["category_id"]), TreeNode = child });
        categories.Remove(current);
      }
      return rootNode;
    }
    
    struct TreeNodeAndId
    {
      public TreeNode TreeNode;
      public int? Id;
    }
