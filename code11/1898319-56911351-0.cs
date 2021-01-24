	public static class ExpressionHelper 
	{
		public static Func<T, object> GetMemberExpressionFunc<T>(string memberName)
		{
			var parameter = Expression.Parameter(typeof(T));
			Expression source = Expression.PropertyOrField(parameter, memberName);	
			Expression conversion = Expression.Convert(source, typeof(object));
			return Expression.Lambda<Func<T, object>>(conversion, parameter).Compile();
		}
	}	
    static void Main(string[] args)
    {
      	Dictionary<int, MyObj> myColl = BuildDictionary();
			
		string property = "AtomicNumber";    // or whatever property you want your dictionary ordered by
		var func = ExpressionHelper.GetMemberExpressionFunc<MyObj>(property);
		var ordered = myColl.OrderBy(x => func(x.Value));
    }
