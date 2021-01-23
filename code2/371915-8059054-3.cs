	public class Base
	{
		public Base() { fun(); }
		public virtual void fun() { Console.Write(1); }
	}
	public class Derived : Base
	{
		public Derived() { fun(); }
		public override void fun() { Console.Write(2); }
	}
	public class DerivedWithError : Base
	{
		public DerivedWithError() { fun(); }
		public new virtual void fun() { Console.Write(3); }
	}
	...
	// This will print "22".
	Base normal = new Derived();
	Console.WriteLine();
	// This will print "13" !!!
	Base withError = new DerivedWithError ();
	Console.WriteLine();
	// Let's call the methods and see what happens!
	// This will print "2"
	normal.fun();
	Console.WriteLine();
	// This will print "1" !!!
	withError.fun();
	Console.WriteLine(); 
