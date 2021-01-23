    public class A
    {
      public void F()
      {
        Console.WriteLine( "A" );
      }
    }
    public class B : A
    {
      public new void F()
      {
        Console.WriteLine( "B" );
      }
    }
    static void Main( string[] args )
    {
      B b = new B();  
      // write "B"
      b.F();
 
      // write "A"
      A a = b;
      b.F();
    }
 
