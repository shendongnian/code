    public static class MyExtensions
    {
      public static void MyMethod( this MyInterface obj, string txt )
      {
      }
    }
    
    public interface MyInterface {}
    
    public class MyDerived : MyInterface
    {
      void DoStuff()
      {
    	this.MyMethod( "test" ); // fails; compiler can't find MyMethod?
      }
    }
