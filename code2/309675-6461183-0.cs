    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myList = new List<Foo>() { 
                    new Foo(){ prop = "a", anotherProp = "z"},
                    new Foo(){ prop = "a", anotherProp = "x"},
                    new Foo(){ prop = "b", anotherProp = "x"},
                    new Foo(){ prop = "b", anotherProp = "y"},
                    new Foo(){ prop = "c", anotherProp = "z"}
                };
    
                // Display groups.
                myList.GroupBy(i => i.prop).ToList().ForEach(j =>
                {
                    Console.WriteLine("\t");
                    j.ToList().ForEach(k => Console.Write(k.prop + ", "));
                });
    
                Console.WriteLine();
                Console.WriteLine(new string('-', 25));
    
                // Display desired output.
                myList.GroupBy(i => i.prop).Select(i => i.First()).ToList().ForEach(i => Console.Write(i.prop + ", "));
                Console.WriteLine();
            }
        }
        public class Foo
        {
            public string prop { get; set; }
            public string anotherProp { get; set; }
        }
    }
