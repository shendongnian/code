	public object invoke(object obj, long l)
	{
		if (typeof(B) == typeof(long))
		{
			if (obj != null)
				l = (long)obj;
			Func<A, long> x = (Func<A, long>)(object)f;
			return x(l);
		} else {
			return f((B)obj);
		}
	}
