	public static Type GetDelegateType(Type[] paramTypes, bool noReturnType)
	{
		if(noReturnType) //Action
		{
			switch (paramTypes.Length)
			{
				case 0: return typeof(Action);
				case 1: return typeof(Action<>).MakeGenericType(paramTypes);
				case 2: return typeof(Action<,>).MakeGenericType(paramTypes);
				...
			}
		}
		else //Func
		{
			switch (paramTypes.Length)
			{
				case 1: return typeof(Func<>).MakeGenericType(paramTypes);
				case 2: return typeof(Func<,>).MakeGenericType(paramTypes);
				...
			}
		}
	}
