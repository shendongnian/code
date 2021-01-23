        using System;
 
        static class Program
        {
    
            static void Main(string[] args)
            {
                
                new Foo();
                new Voyeur();
             
                Console.ReadLine();
            }
  
        }
         public partial class Foo_Impl
        {
             // NOTHING in this public partial implementation. 
             // Visible but cannot be used for anything
            protected Foo_Impl()
            {
                Console.Write("public partial Foo_Impl's protected constructor ");
            }
        }
        public class Foo : Foo_Impl
        {
            private partial class Foo_Impl {
                // put all your secret implementations here that you dont want 
                // any other class to accidentally use (except Foo)
                public int fooAccessibleVariable=42;
                public Foo_Impl ()
                {
                    Console.Write("private partial Foo_Impl contructor ");
                     
            	}
            
            
            
            }
            public Foo():base() // calls the public partial Foo_Impl's construtor
            {
                Console.WriteLine(" called from Foo()");
                Foo_Impl myFoo_Impl =  new Foo_Impl(); // calls the private partial Foo_Imp's constructor
                Console.WriteLine(" called from Foo()");
                Console.WriteLine("private Foo_Impl's variabe thats only accessible to Foo: {0}",
                    myFoo_Impl.fooAccessibleVariable);
            }
        }
        class Voyeur:Foo_Impl
        {
             
            public Voyeur():base()// calls the public partial Foo_Impl's contructor 
            {
                Console.WriteLine("  called from Voyeur()");
                               
            }
        }
