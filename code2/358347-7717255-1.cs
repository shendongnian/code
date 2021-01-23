    public TreeNode GenerateCategoriesTree(List<Category> categories) {
      var s = new Stack<TreeNodeAndId>();
      var rootCategory = categories.Single(o => o.ParentsId == null);
      var rootNode = new TreeNode(rootCategory.Name, rootCategory.Id.ToString());
      s.Push(new TreeNodeAndId { Id = rootCategory.Id, TreeNode = rootNode });
      while (s.Count > 0) {
        var node = s.Peek();
        var current = categories.FirstOrDefault(o => o.ParentId == node.Id);
        if (current == null) {
          s.Pop();
          continue;
        }
        var child = new TreeNode(current.Title, current.Id.ToString());
        node.TreeNode.ChildNodes.Add(child);
        s.Push(new TreeNodeAndId { Id = current.Id, TreeNode = child });
        categories.Remove(current);
      }
      return rootNode;
    }
    
    struct TreeNodeAndId
    {
      public TreeNode TreeNode;
      public int? Id;
    }
