    // Save the path of the expanded tree branches
    var savedExpansionState = treeView1.Nodes.GetExpansionState();
    treeView1.BeginUpdate();
    // TreeView is populated
    // ...
    
    // Once it is populated, we need to restore expanded nodes
    treeView1.Nodes.SetExpansionState(savedExpansionState);
    treeView1.EndUpdate();
