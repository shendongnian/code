    TreeView = new TreeView();
    TreeView.Nodes.Clear();
    foreach (string parentText in xml.parent)
    {
       TreeNode parent = new TreeNode();
       parent.Text = parentText;
       TreeView.Nodes.Add(treeNodeDivisions);
    
       foreach (string childText in xml.child)
       {
          TreeNode Child = new TreeNode();
          child.Text = childText;
          parent.Nodes.Add(child);
       }
    }
