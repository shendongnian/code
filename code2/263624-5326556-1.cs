    TreeView myTreeView = new TreeView();
    myTreeView.Nodes.Clear();
    foreach (string parentText in xml.parent)
    {
       TreeNode parent = new TreeNode();
       parent.Text = parentText;
       myTreeView.Nodes.Add(treeNodeDivisions);
    
       foreach (string childText in xml.child)
       {
          TreeNode child = new TreeNode();
          child.Text = childText;
          parent.Nodes.Add(child);
       }
    }
