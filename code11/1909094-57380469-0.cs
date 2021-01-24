    var groupedUsers = result.GroupBy(t => t.ParentId).SelectMany(t => t.ToList());
    foreach (var item in groupedUsers)
    {
        AddEmployee(item);
    }
    Tree AddEmployee(dynamic item) 
    {
        if (item.ParentId == Guid.Empty)
        {
            var root = new Tree()
            {
                Id = item.Id,
                children = new List<Tree>(),
                isSelected = item.IsDefault,
                Name = item.Name
            }
            treeData.Add(root);
            return root;
        }
        else
        {
            var parent = treeData.FirstOrDefault(t => t.Id == item.ParentId);
            if (parent == null)
            {
                var parentItem = groupedUsers.Single(x => x.Id = item.ParentId);
                parent = AddEmployee(parentItem );
            }
            var child = new Tree()
            {
                Id = item.Id,
                children = new List<Tree>(),
                isSelected = item.IsDefault,
                Name = item.Name
            };
            parent.children.Add(child );
            return child;
        }
    }
