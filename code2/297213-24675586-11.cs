     public class Base 
     {
       public virtual void SomeMethod()
       {
         Console.WriteLine("B");
       }
      }
    public class Derived : Base
    {
       //Same method is written 3 times with different keywords to explain different behaviors. 
       //This one is Simple method
      public void SomeMethod()
      {
         Console.WriteLine("D");
      }
      //This method has 'new' keyword
      public new void SomeMethod()
      {
         Console.WriteLine("D");
      }
      
      //This method has 'override' keyword
      public override void SomeMethod()
      {
         Console.WriteLine("D");
      }
    }
