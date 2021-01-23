    public enum Marble { Red, Green, Blue }
    
    public struct Bag
    {
        public string Name;
        public List<Marble> contents;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
    
            var marbles = new[] { Marble.Red, Marble.Green };
            var bags = new [] 
            {new Bag {Name = "Foo", contents = new List<Marble> {Marble.Blue}},
             new Bag {Name = "Bar", contents = new List<Marble> {Marble.Green, Marble.Red}},
             new Bag {Name = "Baz", contents = new List<Marble> {Marble.Red, Marble.Green, Marble.Blue}}
            };
    
            //Output contains only bag Bar
            var output = bags.AsParallel<Bag>().Where(bag => bag.contents.All(x => marbles.Contains(x)) &&
                                           marbles.All(x => bag.contents.Contains(x)));
    
            output.ForAll<Bag>(bag => Console.WriteLine(bag.Name));  // "Bar"
        }
    }
