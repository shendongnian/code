	int MethodY(int something, int other)
	{
		return UniversalMethod(() => GetResultForMethodY(something, other));
	}
	
	string MethodX(string something)
	{
		return UniversalMethod(() => GetResultForMethodX(something));
	}
	
	T UniversalMethod<T>(Func<T> fetcher)
	{
		T resultObject;
		//nesting preparation code here...
		{
			resultObject = fetcher();
		}
		//nesting result processing code here ...
		return resultObject;
	}
