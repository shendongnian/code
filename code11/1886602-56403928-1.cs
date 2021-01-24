	class Class1<T> where T: new()
	{
		protected int a, b;
		public Class1()
		{
			a = 0;
			b = 0;
			T obj = new T();
			Console.WriteLine("Inside base class default constructor");
		}
		public Class1(int a, int b)
		{
			this.a = a;
			this.b = b;
			T obj = new T();
			Console.WriteLine("Inside base class parameterized constructor");
		}
	}
	class Class2<T> : Class1<T> where T: new()
	{
		int c;
		public Class2(int a, int b, int c) : base(a, b)
		{
			this.c = c;
			Console.WriteLine("Inside derived class parametrized constructor");
		}
	}
	void Main()
	{
		var c2 = new Class2<Derived1>(1, 2, 3);
		Console.WriteLine("-----");
		var c2_2 = new Class2<Derived2>(1, 2, 3);
	}
