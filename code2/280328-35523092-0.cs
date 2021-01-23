    using System;
    					
    public class Program
    {
    	public class C {
    		public C ( string town ) {Town = town;}
    		public string Town { get; private set;}
    	}
    	public class B {
    		public B( C c ) {C = c; }
    		public C C {get; private set; }
    	}
    	public class A {
    		public A( B b ) {B = b; }
    		public B B {get; private set; }
    	}
    	public static void Main()
    	{
    		var a = new A(null);
    		Console.WriteLine( a?.B?.C?.Town ?? "Town is null.");
    	}
    }
 
