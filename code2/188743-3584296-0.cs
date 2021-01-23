    class Program 
      { 
        public class A 
        { 
          public virtual void F(bool useBase) 
          { 
            Console.WriteLine( "A" ); 
          } 
        } 
        public class B : A 
        { 
          public override void F(bool useBase) 
          { 
            if(useBase) base.F();
            else Console.WriteLine( "B" ); 
          } 
        } 
 
        static void Main( string[] args ) 
        { 
            B b = new B();   
 
            //Here I need Invoke Method A.F() , but not overrode..       
            b.F(true);
            Console.ReadKey(); 
            } 
        }
      }
