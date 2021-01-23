    class  Stuff
    {
        public string Cat { get; set; }
        public string Type { get; set; }
        public double Items { get; set; }
    }
    static void Main( string[] args )
    {
        var list = new List<Stuff>();
        list.Add( new Stuff { Cat = "A", Type = "P", Items = 3 } );
        list.Add( new Stuff { Cat = "A", Type = "Q", Items = 4 } );
        list.Add( new Stuff { Cat = "A", Type = "R", Items = 2 } );
        list.Add( new Stuff { Cat = "A", Type = "P", Items = 1 } );
        list.Add( new Stuff { Cat = "A", Type = "Q", Items = 5 } );
        list.Add( new Stuff { Cat = "B", Type = "P", Items = 2 } );
        list.Add( new Stuff { Cat = "B", Type = "Q", Items = 1 } );
        list.Add( new Stuff { Cat = "B", Type = "R", Items = 3 } );
        list.Add( new Stuff { Cat = "B", Type = "P", Items = 9 } );
        var result = from stuff in list
                     group stuff by new { stuff.Cat, stuff.Type } into g
                     select new { Cat = g.Key.Cat,
                                  Type = g.Key.Type,
                                  AvgItems = g.Average( s => s.Items ) };
        foreach( var s in result )
        {
            Console.WriteLine( "{0}  |  {1}  |  {2}", s.Cat, s.Type, s.AvgItems );
        }
    }
