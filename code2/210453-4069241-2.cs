    DepartmentRepository repo = new DepartmentRepository();
    var entries = repo.FindAllDepartments();
    
    var parentDepartments = entries.Where(d => d.IDParentDepartment == null).ToList();
    foreach (var parent in parentDepartments)
    {
        TreeNode node = new TreeNode(parent.Name);
        treeView1.Nodes.Add(node);
    
        var children = entries.Where(x => x.IDParentDepartment == parent.ID).ToList();
        foreach (var child in children)
        {
            node.Nodes.Add(child.Name);
        }
    }
