    var parent = context.Parents
        .Join(context.GenericLinks.Where(gl => gl.EntityTypeID == PARENT_TYPE), 
             p => p.ParentId, 
             gl => gl.EntityId, 
             (p,gl) => new {Parent = p, GenericLink = gl})
       .Where(x => x.ParentId == idToSearchFor)
       .GroupBy(x => x.Parent)
       .Select(x => new ParentDTO
        {
            ParentId = x.Key.ParentId,
            Data1 = x.Key.Data1,
            Data2 = x.Key.Data2,
            Data3 = x.Key.Data3,
            Children = x.Key.Children.Select(c => new ChildDTO
            {
                ChildId = c.ChildId,
                ChildTypeId = c.ChildType.ChildTypeId,
                ChildTypeName = c.ChildType.TypeName,
                StatusId = c.Status.StatusId,
                StatusName = c.Status.StatusName
            }).ToList(),
            SubItems = x.Select(g => new SubItemDto 
            { 
               Data1 = g.SubItem.Data1,
               Data2 = g.SubItem.Data2,
               // ...
            }).ToList();
        }).Single();
