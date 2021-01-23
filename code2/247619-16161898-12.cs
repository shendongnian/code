    private T CacheAction<T>(Expression<Func<T>> action, [CallerMemberName] string memberName = "") where T : class
	{
		MethodCallExpression body = (MethodCallExpression)action.Body;
		ICollection<object> parameters = new List<object>();
		foreach (MemberExpression expression in body.Arguments)
		{
			parameters.Add(((FieldInfo)expression.Member).GetValue(((ConstantExpression)expression.Expression).Value));
		}
		StringBuilder builder = new StringBuilder(100);
		builder.Append(GetType().FullName);
		builder.Append(".");
		builder.Append(memberName);
		parameters.ToList().ForEach(x =>
		{
			builder.Append("_");
			builder.Append(x);
		});
		string cacheKey = builder.ToString();
		T retrieve = Cache.Retrieve<T>(cacheKey);
		if (retrieve == null)
		{
			retrieve = action.Compile().Invoke();
			Cache.Store(cacheKey, retrieve);
		}
		return retrieve;
	}
	public Customer GetCustomerByID(int customerID)
	{
		return CacheAction(() => CustomerRepository.GetCustomerByID(customerID));
	}
