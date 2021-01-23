     public class Base 
     {
       public virtual void SomeMethod()
       {
         Console.WriteLine("B");
       }
      }
       //This one is Simple method
    public class Derived : Base
    {
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
