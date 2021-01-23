    void Main(string[] args) {
    		// baseline
    		var g0 = new DefinitelyNothing();					g0.foo(); // "foo"
    		
    		ISomething g;
    		
    		// won't work, not ISomething
    		// g = new DefinitelyNothing();		g.foo();
    		
    		g = new DefinitelyNothingThatThinksItsSomething();	g.foo(); // "bar"
    			new DefinitelyNothingThatThinksItsSomething().foo(); 	// "foo"
    			
    		g = new DefinitelySomething();						g.foo(); // "bar"
    			new DefinitelySomething().foo();						// "foo"
    			
    		g = new DefinitelySomethingWithFoo();				g.foo(); // "bar"
    			new DefinitelySomethingWithFoo().foo();					// "foo"
    			(g as IWithFoo).foo();									// "foo", not "qux"
    			
    		g = new DefinitelySomethingFromNothingWithFoo();	g.foo(); // "bar"
    			new DefinitelySomethingFromNothingWithFoo().foo();		// "foo"
    			(g as ISomethingWithFoo).foo();							// "foo", not "baz"
    		
    		IWithFoo g1;
    		g1 = new DefinitelyNothingWithFoo();				g1.foo(); // "foo"
    			new DefinitelyNothingWithFoo().foo();					 // "foo"
    }
    
    public interface ISomething {}
    public interface IWithFoo {
    	void foo();
    }
    public interface ISomethingWithFoo : ISomething, IWithFoo {}
    
    public abstract class Nothing {
    	public void foo() { Console.WriteLine("foo"); }
    }
    public abstract class NothingWithFoo : IWithFoo {
    	public void foo() { Console.WriteLine("foo"); }
    }
    public abstract class Something : ISomething {
    	public void foo() { Console.WriteLine("foo"); }
    }
    public abstract class SomethingWithFoo : ISomethingWithFoo {
    	public void foo() { Console.WriteLine("foo"); }
    }
    public abstract class SomethingFromNothingWithFoo : Nothing, ISomethingWithFoo {}
    
    public class DefinitelyNothing: Nothing {}
    public class DefinitelyNothingThatThinksItsSomething: Nothing, ISomething {}
    public class DefinitelyNothingWithFoo : NothingWithFoo {}
    
    public class DefinitelySomething : Something {}
    public class DefinitelySomethingWithFoo : SomethingWithFoo {}
    public class DefinitelySomethingFromNothingWithFoo : SomethingFromNothingWithFoo {}
    
    
    public static class ISomethingExtensions {
    	// http://en.wikipedia.org/wiki/Metasyntactic_variable
    	public static void foo(this ISomething whatever) { Console.WriteLine("bar"); }
    	public static void foo(this ISomethingWithFoo whatever) { Console.WriteLine("baz"); }
    	public static void foo(this IWithFoo whatever) { Console.WriteLine("qux"); }
    }
