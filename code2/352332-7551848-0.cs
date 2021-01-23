	void Main()
	{	
		var b = new ClassB();
		var a = (ClassA)b;
		a.name = "hello";
		b.PrintName();
	}
	
	class ClassA {
		public string name;
	}
	
	class ClassB : ClassA  {
		private new string name;
		public void PrintName() {
			Console.WriteLine(base.name);
		}
	}
