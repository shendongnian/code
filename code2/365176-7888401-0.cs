	public T GetSelfOrMaxValue<T>(T value)
	{
		var t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
		var fi = t.GetField("MaxValue");
		if (fi != null && fi.IsStatic && fi.FieldType.Equals(t))
		{
			return (T)fi.GetValue(null);
		}
		return value;
	}
