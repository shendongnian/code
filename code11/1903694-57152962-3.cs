    public class Foo : IFoo
	{
		public Lazy<Task<int>> MyLazy { get; private set; }
        // ...
    }
