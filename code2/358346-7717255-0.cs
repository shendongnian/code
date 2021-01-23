    public TreeNode GenerateTopicsTree(List<Topic> topics) {
      var s = new Stack<TreeNodeAndId>();
      var root = new TreeNode("Topics", "0");
      s.Push(new TreeNodeAndId { Id = null, TreeNode = root });
      while (s.Count > 0) {
        var node = s.Peek();
        var current = topics.FirstOrDefault(o => o.ParentId == node.Id);
        if (current == null) {
          s.Pop();
          continue;
        }
        var child = new TreeNode(current.Title, current.Id.ToString());
        node.TreeNode.ChildNodes.Add(child);
        s.Push(new TreeNodeAndId { Id = current.Id, TreeNode = child });
        topics.Remove(current);
      }
      return root;
    }
    
    struct TreeNodeAndId
    {
      public TreeNode TreeNode;
      public int? Id;
    }
