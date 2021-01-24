	public class TestClass
	{
		private readonly string something;
	
		public TestClass(string something)
		{
			this.something = something;
		}
		public override string ToString()
		{
			return something;
		}
	}
	TestClass test = new TestClass("alpha");
	Console.Write(test);
