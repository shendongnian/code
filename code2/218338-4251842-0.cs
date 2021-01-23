	abstract class A
	{
		protected virtual string Foo()
		{
			return "A";
		}
	}
	abstract class B : A
	{
		protected new virtual string Foo()
		{
			return "B";
		}
	}
	class C : B
	{
		protected override string Foo()
		{
			return "C";
		}
