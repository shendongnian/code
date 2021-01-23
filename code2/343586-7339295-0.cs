    ParameterExpression x = …;
    var navigationProperty = typeof(EntityB).GetProperty("NavigationProperty");
    var name = typeof(EntityBDetails).GetProperty("Name");
    
    var navigationPropertyAccess = Expression.MakeMemberAccess(x, navigationProperty);
    var nameAccess = Expression.MakeMemberAccess(navigationPropertyAccess , name);
