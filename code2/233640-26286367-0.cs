    interface IFace<T> {}
    class Impl<T> : IFace<T> {}
    class Derived<T> : Impl<T> {}
	public static bool InheritsFrom(this Type tDerived, Type tBase)
	{
		if (tDerived.IsSubtypeOf(tBase)) return true;
		var interfaces = tDerived.GetInterfaces()
                                 .Select(i => i.IsGenericType ? i.GetGenericTypeDefinition() : i);
		return interfaces.Contains(tBase);
	}
	public static bool IsSubtypeOf(this Type tDerived, Type tBase)
	{
		var currentType = tDerived.BaseType;
		while (currentType != null)
		{
			if (currentType.IsGenericType)
				currentType = currentType.GetGenericTypeDefinition();
			if (currentType == tBase) return true;
			currentType = currentType.BaseType;
		}
		return false;
	}
