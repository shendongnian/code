    public static class QueryBuilder {
        private static MethodInfo containsMethod = typeof(Enumerable).GetMethods().Single(mi => mi.Name == "Contains" && mi.GetParameters().Length == 2).MakeGenericMethod(typeof(int));
    
        public static MethodCallExpression qContains(this Expression p, int attrib) => Expression.Call(containsMethod, p, Expression.Constant(attrib));
        public static BinaryExpression qAnd(this Expression l, Expression r) => Expression.AndAlso(l, r);
        public static BinaryExpression qOr(this Expression l, Expression r) => Expression.OrElse(l, r);
    
        static ParameterExpression digParm = Expression.Parameter(typeof(DocItemJoin), "dig");
        static MemberExpression digParmig = Expression.Property(digParm, "ig");
    
        public static MethodCallExpression HasAttrib(this int attrib) => digParmig.qContains(attrib);
        
        static Expression<Func<DocItemJoin, Documents>> selectLambda = Expression.Lambda<Func<DocItemJoin, Documents>>(Expression.Property(digParm, "d"), digParm);
        
        public static IQueryable<Documents> Query(this IQueryable<DocItemJoin> src, Expression whereBody)
            => src.Where(Expression.Lambda<Func<DocItemJoin, bool>>(whereBody, digParm)).Select(selectLambda);
    }
