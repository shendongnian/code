	static void Main()
	{
		ITest x = new TestDerived();
		x.Name();
	}
	
	interface ITest {
		void Name();
	}
	
	class TestBase : ITest {
		public void Name() { Console.WriteLine("Base"); }
	}
	class TestDerived : TestBase, ITest {
		public void Name() { Console.WriteLine("Derived"); }
	}
