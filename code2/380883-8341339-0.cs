        public static IQueryable CountCompile(this IQueryable source)
        {
            // you should cache this MethodInfo
            return (IQueryable)source.Provider.GetType().GetMethod("CreateQuery", BindingFlags.NonPublic | BindingFlags.Instance, null,
                                                new[] {typeof (Expression), typeof (Type)}, null)
                .Invoke(source.Provider, new object[]
                                             {
                                                 Expression.Call(
                                                     typeof (Queryable), "Count",
                                                     new[] {source.ElementType}, source.Expression),
                                                 source.ElementType
                                             });
        }
