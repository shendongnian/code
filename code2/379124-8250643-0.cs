	public static void DoAs<T>(this object @this, Action<T> action)
		where T : class
	{
		var t = @this as T;
		if (t != null)
		{
			var a = action;
			if (a != null)
			{
				a(t);
			}
		}
	}
