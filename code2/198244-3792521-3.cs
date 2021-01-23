        using System;
        using System.Collections.Generic;
        using System.Linq;
        namespace Project
        {
                public enum Marble { Red, Green, Blue}
                public class Bag {
                    public string Name;
                    public List<Marble> contents;
                }
        
        class Program
        {
        
            static void Main()
            {
                var marbles = new[] { Marble.Red, Marble.Green };
                var bags = new[] 
                        {new Bag {Name = "Foo", contents = new List<Marble> {Marble.Blue}},
                         new Bag {Name = "Bar", contents = new List<Marble> {Marble.Green, Marble.Red}},
                         new Bag {Name = "Baz", contents = new List<Marble> {Marble.Red, Marble.Green, Marble.Blue}},
                         new Bag {Name = "Foo", contents = new List<Marble> {Marble.Blue}},
                         new Bag {Name = "Bar", contents = new List<Marble> {Marble.Green, Marble.Red}},
                         new Bag {Name = "Fiz", contents = new List<Marble> {Marble.Red, Marble.Green}},
                         new Bag {Name = "REDS", contents = new List<Marble> {Marble.Red, Marble.Red}},
                         new Bag {Name = "Biz", contents = new List<Marble> { Marble.Red } }, 
                         new Bag {Name = "Griz", contents = new List<Marble> {Marble.Green, Marble.Green, Marble.Blue}},
                         new Bag {Name = "Baz", contents = new List<Marble> {Marble.Red, Marble.Green, Marble.Blue}}
                        };
                      
 
                     
                
                
              // the  query with set substraction   operator
               var  query_v2      = bags.Where(bag => bag.contents.Except(marbles).Count() == 0 &&
                                               marbles.Except(bag.contents).Count() == 0                                            
                                        );
         
            
                   // print out the results 
            
                   Console.WriteLine("query_v2...");
         
                   foreach (var bag in query_v2)
                   {
                       Console.WriteLine(bag.Name);
                   }
               Console.WriteLine();
      
               // Follwowing is a LINQ Expression version
               //
               var linqversion = from bag in bags
                                 let diff1 = bag.contents.Except(marbles).Count()
                                 let diff2 = marbles.Except(bag.contents).Count()
                                 where diff1 == 0 && diff2 == 0 // perfect match ?
                                 select bag;
               Console.WriteLine("Linq expression version output...");
                foreach (var bag in linqversion)
                {
                    Console.WriteLine(bag.Name);
                }
            
                Console.ReadLine();
            }
         
        }
    }
