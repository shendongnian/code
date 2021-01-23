    public class Class1
	{
		public void DoSomething()
		{
		}
	}
	public class Class2
	{
		public Class2()
		{
			Class1 myClass1 = new Class1();
			myClass1.DoSomething();
		}
	}
