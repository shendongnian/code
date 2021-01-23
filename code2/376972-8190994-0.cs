    static void Main(string[] args) {
        var dummys = new List<int>(); dummys.Add(1);
        var col1 = from dummy in dummys
                   select new { Name1 = "Frank", ID1 = 123, ABC = "abc" };
        var col2 = from dummy in dummys
                   select new { Name2 = "Harry", ID2 = 456, XYZ = "xyz" };
        var col3 = from dummy in dummys
                   select new { Name3 = "Bob" };
        var col4 = col1.Select(c=> new { FirstName=c.Name1, Ident=new Nullable<int>(c.ID1)})
            .Union(col2.Select(c=> new { FirstName=c.Name2, Ident=new Nullable<int>(c.ID2)}))
            .Union(col3.Select(c=> new { FirstName=c.Name3, Ident=new Nullable<int>()}));
        foreach (var c in col4) {
            Console.WriteLine(c);
        }
        Console.ReadKey();
    }
