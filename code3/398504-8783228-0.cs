	class A {
		public int val = 5;
		public static void Main(string[] args) {
			B b = new B();
			A a = (A)b;
			Console.WriteLine(a.val); // 5
			Console.WriteLine(b.val); // 10
		}
	}
	class B : A {
		public int val = 10;
	}
