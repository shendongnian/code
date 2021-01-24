    using System;
    public class Foo1
    {
  	  // static
	  public static void Method( string s )
  	  {
  	  } 
    }
    public class Foo2
    {
	  // instance
	  public void Method( string s )
  	  {
	  }
    }
    public class Program
    {
	  public static void  Main(string[] args)
	  {
	  	PrintDelegateInfo( Foo1.Method );
		PrintDelegateInfo( new Foo2().Method );
		PrintDelegateInfo( (Action<string>)(s => {}) );
	  }
 	  private static void PrintDelegateInfo(Action<string> funcToCall)
	  {
	    var methodInfo = funcToCall.Method;
		var name = string.Format( "{0}.{1}", methodInfo.DeclaringType.Name, methodInfo.Name );
		
		Console.WriteLine( "{0} called", name );
	  }
    }
