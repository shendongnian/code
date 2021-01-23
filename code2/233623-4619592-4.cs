    class Program
    {
    
    	public static class Memoize
    	{
    		public static Cache LocalCache = 
    			System.Web.HttpRuntime.Cache ?? System.Web.HttpContext.Current.Cache;
    
    		public static TResult ResultOf<TArg1, TResult>(
    			Func<TArg1, TResult> func, 
    			TArg1 arg1, 
    			long durationInSeconds)
    		{
    			var key = HashArguments(
    				func.Method.DeclaringType.GUID,
    				typeof(TArg1).GUID, 
    				(object)arg1);
    			return Complete(key, durationInSeconds, () => func(arg1));
    		}
    
    		public static TResult ResultOf<TArg1, TArg2, TResult>(
    			Func<TArg1, TArg2, TResult> func, 
    			TArg1 arg1, 
    			TArg2 arg2, 
    			long durationInSeconds)
    		{
    			var key = HashArguments(
    				func.Method.DeclaringType.GUID,
    				typeof(TArg1).GUID, 
    				(object)arg1, 
    				typeof(TArg2).GUID, 
    				(object)arg2);
    			return Complete(key, durationInSeconds, () => func(arg1, arg2));
    		}
    
    		public static TResult ResultOf<TArg1, TArg2, TArg3, TResult>(
    			Func<TArg1, TArg2, TArg3, TResult> func, 
    			TArg1 arg1, 
    			TArg2 arg2, 
    			TArg3 arg3, 
    			long durationInSeconds)
    		{
    			var key = HashArguments(
    				func.Method.DeclaringType.GUID,
    				typeof(TArg1).GUID, 
    				(object)arg1, 
    				typeof(TArg2).GUID, 
    				(object)arg2, 
    				typeof(TArg3).GUID, 
    				(object)arg3);
    			return Complete(key, durationInSeconds, () => func(arg1, arg2, arg3));
    		}
    
    		public static void Reset()
    		{
    			var enumerator = LocalCache.GetEnumerator();
    			while (enumerator.MoveNext())
    				LocalCache.Remove(enumerator.Key.ToString());
    		}
    
    		private static T CacheResult<T>(string key, long durationInSeconds, T value)
    		{
    			LocalCache.Insert(
    				key, 
    				value, 
    				null, 
    				DateTime.Now.AddSeconds(durationInSeconds), 
    				new TimeSpan());
    			return value;
    		}
    
    		static T Complete<T>(string key, long durationInSeconds, Func<T> valueFunc)
    		{
    			return LocalCache.Get(key) != null
    			   ? (T)LocalCache.Get(key)
    			   : CacheResult(key, durationInSeconds, valueFunc());
    		}
    
    		static string HashArguments(params object[] args)
    		{
    			if (args == null)
    				return "null args";
    
    			int result = 23;
    			for (int i = 0; i < args.Length; i++)
    			{
    				var arg = args[i];
    				if (arg == null)
    				{
    					result = 31 * result + (i + 1);
						continue;
    				}
    				result = 31 * result + arg.GetHashCode();
    			}
    			return result.ToString();
    		}
    	}
    
    	static int test(int a, int b)
    	{
    		return a + b;
    	}
    
    	private static class Inner
    	{
    		public static int test(int a, int b)
    		{
    			return a + b;
    		}
    	}
    
    	static int test(int a, object b)
    	{
    		return a + (int)b;
    	}
    
    	static void Main(string[] args)
    	{
    		Memoize.ResultOf<int, int, int>(test, 1, 2, 100000);
    		Memoize.ResultOf<int, int, int>(test, 2, 1, 100000);
    		Memoize.ResultOf<int, int, int>(Inner.test, 1, 2, 100000);
    		Memoize.ResultOf<int, int, int>(Inner.test, 2, 1, 100000);
    		Memoize.ResultOf<int, object, int>(test, 1, 2, 100000);
    		Memoize.ResultOf<int, object, int>(test, 2, 1, 100000);
    	}
    }
