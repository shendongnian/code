            var marbles = new[] { Marble.Red, Marble.Green };
            var bags = new[] 
                    {new Bag {Name = "Foo", contents = new List<Marble> {Marble.Blue}},
                     new Bag {Name = "Bar", contents = new List<Marble> {Marble.Green, Marble.Red}},
                     new Bag {Name = "Baz", contents = new List<Marble> {Marble.Red, Marble.Green, Marble.Blue}}
                    };
                      
            var matched_bags = from bag in bags
                          from marble in marbles
                          where bag.contents.Contains(marble)
                          group bag by bag.Name into g
                          select new Bag { Name = g.First().Name, contents = g.First().contents }
                          ;
 
            foreach (var bag in matched_bags)
            {
                Console.WriteLine(bag.Name);
            }
            Console.ReadLine();
