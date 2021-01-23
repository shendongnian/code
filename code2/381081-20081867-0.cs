    var savedExpandedStates = treeView1.Nodes.OfType<TreeNode>()
                                       .Descendants(n => n.Nodes.OfType<TreeNode>())
                                       .Where(n => n.IsExpanded)
                                       .Select(n => n.FullPath)
                                       .ToList();
    treeView1.BeginUpdate();
    // TreeView is populated and refreshed at this time
    // ...
    foreach(var node in treeView1.Nodes.OfType<TreeNode>()
                                 .Descendants(n => n.Nodes.OfType<TreeNode>())
                                 .Where(n => savedExpandedStates.Contains(n.FullPath)))
    {                        
        node.Expand();
    }
    treeView1.EndUpdate();
