	using System;
	
	class A {
		public static A getInstance() { return new A(); }
		public void PrintSelf() {Console.WriteLine(this.GetType().Name);}
	}
	
	class B : A {   
		public static new B getInstance() {
		return new B();
	}
	}
	
	public class MyClass {
		public static void Main() {
			A a = A.getInstance();
			B b = B.getInstance();
			a.PrintSelf();
			b.PrintSelf();
		}
	}
