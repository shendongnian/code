	public class Foo : IFoo
	{
		public Lazy<Task<int>> MyLazy { get; }
		
		public Foo()
		{
			MyLazy = new Lazy<Task<int>>(() => Task.FromResult(3));	
		}
	}
