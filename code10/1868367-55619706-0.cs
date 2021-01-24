    public static class QueryableExtensions
    {
    	public static IQueryable<T> SelectMembers<T>(this IQueryable<T> source, IEnumerable<string> memberPaths)
    	{
    		var parameter = Expression.Parameter(typeof(T), "item");
    		var body = parameter.Select(memberPaths.Select(path => path.Split('.')));
    		var selector = Expression.Lambda<Func<T, T>>(body, parameter);
    		return source.Select(selector);
    	}
    
    	static Expression Select(this Expression source, IEnumerable<string[]> memberPaths, int depth = 0)
    	{
    		var bindings = memberPaths
    			.Where(path => depth < path.Length)
    			.GroupBy(path => path[depth], (name, items) =>
    			{
    				var item = Expression.PropertyOrField(source, name);
    				return Expression.Bind(item.Member, item.Select(items, depth + 1));
    			}).ToList();
    		if (bindings.Count == 0) return source;
    		return Expression.MemberInit(Expression.New(source.Type), bindings);
    	}
    }
