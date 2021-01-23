	public static partial class Lambda
	{
		public static Action Pin<T0>
			(
				this Action<T0> action,
				T0 arg0
			)
		{
			return () => action(arg0);
		}
		public static Func<TResult> Pin<T0, TResult>
			(
				this Func<T0, TResult> func,
				T0 arg0
			)
		{
			return () => func(arg0);
		}
		public static Action Pin<T0, T1>
			(
				this Action<T0, T1> action,
				T0 arg0,
				T1 arg1
			)
		{
			return () => action(arg0, arg1);
		}
		public static Func<TResult> Pin<T0, T1, TResult>
			(
				this Func<T0, T1, TResult> func,
				T0 arg0,
				T1 arg1
			)
		{
			return () => func(arg0, arg1);
		}
		// More signatures omitted for brevity...
		// I would love it if C# supported variadic template parameters :-)
	}
