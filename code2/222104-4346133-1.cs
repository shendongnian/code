    using System.Collections.Generic;
    
    public class Foo
    {
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return Name + ": " + IsAvailable;
        }
    }
    
    class Test
    {
        static void Main()
        {
            List<Foo> list = new List<Foo>()
            {
                new Foo { Name = "First", IsAvailable = true },
                new Foo { Name = "Second", IsAvailable = false },
                new Foo { Name = "Third", IsAvailable = false },
            };
            
            Console.WriteLine("Before:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine();
            
            foreach (Foo foo in list)
            {
                foo.IsAvailable = true;
            }
            
            Console.WriteLine("After:");
            list.ForEach(Console.WriteLine);
        }
    }
