	public sealed class UsesFoo : IDisposable
	{
		public Foo MyFoo { get; }
		public UsesFoo(Foo foo)
		{
			MyFoo = foo;
		}
		public void Dispose()
		{
			MyFoo?.Dispose();
		}
	}
	public static class UsesFooFactory
	{
		public static UsesFoo Create()
		{
			var bar = new Bar();
			bar.SomeEvent += Bar_SomeEvent;
			return new UsesFoo(bar);
		}
		private static void Bar_SomeEvent(object sender, EventArgs e)
		{
			//Do stuff
		}
	}
