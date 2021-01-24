    void Main()
    {
        Test<Test>();
    }
    static void Test<T>() where T : class
    {
        PropertyInfo propertyInfo = typeof(T).GetProperty("col1");
        var parameter = Expression.Parameter(typeof(T), "x");
        //create where clause expression
        var orgIdMember = Expression.Property(parameter, "col1");
        ConstantExpression orgIdConstant = Expression.Constant(new Guid("d3aaaf86-d4e5-4d77-897e-1b36c1100448"), typeof(Guid));
        var orgIdBody = Expression.Equal(orgIdMember, orgIdConstant);
        var orgIdWhereExpression = Expression.Lambda<Func<Test, bool>>(orgIdBody, parameter); 
        TypedDataContext d = new TypedDataContext();
        
        var query = d.Tests.AsQueryable().Where(orgIdWhereExpression);
        //create start point expression 
        Guid startPoint = new Guid("09e0073a-be0e-405a-9564-d34056c8e42a");
            
        var startPointMember = Expression.Property(parameter, "col2");
        ConstantExpression startPointConstant = Expression.Constant(startPoint, startPoint.GetType());
        var left = Expression.Call(startPointMember, typeof(Guid).GetMethod("CompareTo", new Type[] { typeof(Guid) }), startPointConstant);
        var right = Expression.Constant(1);
        var startPointBody = Expression.Equal(left, right);
        var startPointWhereExpression = Expression.Lambda<Func<Test, bool>>(startPointBody, parameter);
        query = query.Where(startPointWhereExpression);
        MemberExpression keyMember = Expression.Property(parameter, "col1");
        var keyExpression = Expression.Lambda<Func<Test, Guid>>(keyMember, parameter);
        query = query.OrderBy(keyExpression);
        
        query.ToList().Dump();
    }
