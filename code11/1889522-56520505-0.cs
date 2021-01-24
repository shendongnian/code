	void Main()
	{
		var person = new Person();
		WeakReference<Person> weak = new WeakReference<Person>(person);
		person = null;
		
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine($"{i}\t{TestReference(weak)}");
			Thread.Sleep(100);
		}
		
		GC.Collect();
		Console.WriteLine(TestReference(weak));
	}
	
	class Person
	{
		private int mI = 3;
		public int MI { get => mI; set => mI = value; }
	}
	
	bool TestReference(WeakReference<Person> weak)
	{
		if (weak.TryGetTarget(out Person p))
		{
			p = null;
			return true;
		}
		return false;
	}
