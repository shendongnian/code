	abstract class SomeClass : ISomeInterface
	{
		public abstract void Method1();
		public abstract void Method2();
		public abstract void Method3();
		// The template method
		public void Start()
		{
			testClass.Method1();
			testClass.Method2();
			testClass.Method3();
		}
	}
	class ImplementationClass : SomeClass
	{
		public override void Method1()
		{
			...
		}
		public override void Method2()
		{
			...
		}
		public override void Method3()
		{
			...
		}
	}
    // Usage
    var implementationClass = new ImplementationClass();
    implementationClass.Start();
