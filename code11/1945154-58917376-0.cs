cs
    public static class Agent
	{
		private static Lazy<Foo> _lazy;
		public static Foo Instance => _lazy?.Value ?? throw new InvalidOperationException("Please, setup the instance");
		public static bool IsInstanceCreated => _lazy?.IsValueCreated ?? false;
		public static void Setup(Bar bar)
		{
			_lazy = new Lazy<Foo>(() => new Foo(bar));
		}
	}
