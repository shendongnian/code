    var entityType = options.Context.ElementType as IEdmEntityType;
    var edmProperty = entityType.FindProperty(newSortText);
    var nodeDirection = options.OrderBy.OrderByNodes.First().Direction;
    options.OrderBy.OrderByNodes.Clear();
    options.OrderBy.OrderByNodes.Add(new OrderByPropertyNode(
    	edmProperty,
    	nodeDirection));
