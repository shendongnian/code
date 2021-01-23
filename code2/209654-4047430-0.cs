	public static T ConvertDelegate<T>(Delegate d)
	{
		if (!(typeof(T).IsSubclassOf(typeof(Delegate))))
			throw new ArgumentException("T is no Delegate");
		if (d == null)
			throw new ArgumentNullException();
		MulticastDelegate md = d as MulticastDelegate;
		Delegate[] invList = null;
		int invCount = 1;
		if (md != null)
			invList = md.GetInvocationList();
		if (invList != null)
			invCount = invList.Length;
		if (invCount == 1)
		{
			return (T)(object)Delegate.CreateDelegate(typeof(T), d.Target, d.Method);
		}
		else
		{
			for (int i = 0; i < invList.Length; i++)
			{
				invList[i] = (Delegate)(object)ConvertDelegate<T>(invList[i]);
				}
				return (T)(object)MulticastDelegate.Combine(invList);
			}
		}
    
    public static TDelegate Extend<TDelegate,TArg,TResult>(Func<TArg,TResult> functionToWrap)
    where TDelegate:class
    	{		
    		Func<TArg,TResult> wrappedFunc= DoTheWrapping(functionToWrap);
    		return ConvertDelegate<TDelegate>(wrappedFunc);
    	}
