	class FooService : IFooService
	{
		protected Lazy<IBarService> _bar;
		public FooService(Lazy<IBarService> bar)
		{
			_bar = bar;
		}
		public void DoSomething(bool callOtherService)
		{
			Console.WriteLine("Hello world. I am Foo.");
			if (callOtherService)
			{
				_bar.Value.DoSomethingElse(false);
			}
		}
	}
	class BarService : IBarService
	{
		protected Lazy<IFooService> _foo;
		public BarService(Lazy<IFooService> foo)
		{
			_foo = foo;
		}
		public void DoSomethingElse(bool callOtherService)
		{
			Console.WriteLine("Hello world. I am Bar.");
			if (callOtherService)
			{
				_foo.Value.DoSomething(false);
			}
		}
	}
