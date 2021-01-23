	public interface IFoo
	{
		void Write(string value);
	}
	public class Bar
	{
		private readonly IFoo _foo;
		public Bar(IFoo foo)
		{
			_foo = foo;
		}
		public void Save(string value)
		{
			_foo.Write(value);
		}
	}
