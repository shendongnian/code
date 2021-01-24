	class Class2 : Class1
	{
		int c;
		public Class2(int a, int b, int c) : base(a, b, typeof(Derived1))
		{
			this.c = c;
			Console.WriteLine("Inside derived class parametrized constructor");
		}
	}
	void Main()
	{
		Class2 c2 = new Class2(1,2, 3);
	}
