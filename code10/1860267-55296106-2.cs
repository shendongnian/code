    static Expression Property(Expression target, string name) =>
    	name.Split('.').Aggregate(target, SimpleProperty);
    
    static Expression SimpleProperty(Expression target, string name) =>
    	Expression.MakeMemberAccess(target, GetProperty(target.Type, name));
