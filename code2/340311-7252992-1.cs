	private Action<object> Switch(params Func<object, Action>[] tests)
	{
		return o =>
		{
			var @case = tests
				.Select(f => f(o))
				.FirstOrDefault(a => a != null);
				
			if (@case != null)
			{
				@case();
			}
		};
	}
	
	private Func<object, Action> Case<T>(Action<T> action)
	{
		return o => o is T ? (Action)(() => action((T)o)) : (Action)null;
	}
