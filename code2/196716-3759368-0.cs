	interface A
	{
		void f();
		void g();
	}
	abstract class B : A
	{
		public void f()
		{
			Console.WriteLine("B.f()");
		}
		public abstract void g();
	}
	class C : B
	{
		public override void g()
		{
			Console.WriteLine("C.g()");
		}
	}
