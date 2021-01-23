    using System;
    namespace ConsoleApp
    {     
         public static class Program
         {   
              public static void Main(string[] args)
              {    
                   Overrider overrider = new Overrider();
                   Base base1 = overrider;
                   overrider.Foo();
                   base1.Foo();
            
                   Hider hider = new Hider();
                   Base base2 = hider;
                   hider.Foo();
                   base2.Foo();
              }   
         }   
    
         public class Base
         {
             public virtual void Foo()
             {
                 Console.WriteLine("Base      => Foo");
             }
         }
    
         public class Overrider : Base
         {
             public override void Foo()
             {
                 Console.WriteLine("Overrider => Foo");
             }
         }
    
         public class Hider : Base
         {
             public new void Foo()
             {
                 Console.WriteLine("Hider     => Foo");
             }
         }
    }    
