    var entityType = typeof(User);
    var metaType = dataContext.Mapping.GetMetaType(entityType);
    var member = metaType.DataMembers.Single(m => m.IsPrimaryKey).Member;
    var param = Expression.Parameter(entityType);
    var body = Expression.Equal(Expression.MakeMemberAccess(param, member),
        Expression.MakeMemberAccess(Expression.Constant(entity), member));
    dynamic table = dataContext.GetTable(entityType);
    object result = Cheeky(table, body, param);
