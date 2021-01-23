        using System;
 
        static class Program
        {
    
            static void Main(string[] args)
            {
                Console.WriteLine();
                new Foo();
                new Voyeur();
             
                Console.ReadLine();
            }
  
        }
        public class Foo_Impl
        {
            protected Foo_Impl()
            {
                Console.WriteLine("Foo_Impl constructor called ");
            }
        }
        public class Foo : Foo_Impl
        {
            public Foo(): base()
            {
        
            }
        }
        class Voyeur
        {
            public Voyeur()
            {
                Foo_Impl fi =
                    new Foo_Impl();//Error: 'Foo_Impl.Foo_Impl()' is inaccessible due to its protection level   }
            }
        }
