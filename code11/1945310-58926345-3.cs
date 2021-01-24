    var parent = context.Parents.Where(x => x.ParentId == idToSearchFor)
        .Select(x => new ParentDTO
        {
            ParentId = x.ParentId,
            Data1 = x.Data1,
            Data2 = x.Data2,
            Data3 = x.Data3,
            Children = x.Children.Select(c => new ChildDTO
            {
                ChildId = c.ChildId,
                ChildTypeId = c.ChildType.ChildTypeId,
                ChildTypeName = c.ChildType.TypeName,
                StatusId = c.Status.StatusId,
                StatusName = c.Status.StatusName
            }).ToList()
        }).Single();
    
    var subItems = context.GenericLinks.Where(x => x.EntityTypeID == PARENT_TYPE 
        && x.EntityID == idToSearchFor)
       .SelectMany(x => SubItems.Select(s => new SubItemDto { /* Fill details like above */ }).ToList();
    
    parent.SubItems = subItems;
