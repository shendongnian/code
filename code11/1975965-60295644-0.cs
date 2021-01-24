    using System.Linq;
    ...
    private static TreeNode AddNodes<T>(TreeView tree, IEnumerable<T> items) {
      if (null == tree)
        throw new ArgumentNullException(nameof(tree));
      else if (null == items)
        throw new ArgumentNullException(nameof(items));
      bool found = true;
      TreeNodeCollection nodes = tree.Nodes;
      TreeNode node = null; 
      foreach (var item in items.Reverse()) {
        if (found) {
          node = nodes.OfType<TreeNode>().FirstOrDefault(nd => object.Equals(nd.Tag, item));
          found = node != null;
        }
        if (!found) {
          node = new TreeNode(item?.ToString());
          node.Tag = item;
          nodes.Add(node);
        }
        nodes = node.Nodes;
      }
      return node;
    }
