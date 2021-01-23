    List<string> list = new List<string> { "a", "b", "a", "c", "a", "d", "c" };
    var counts = from item in list
                 group item by item
                     into grp
                     orderby grp.Count() descending
                     select new
                                {
                                    Value = grp.Key,
                                    Count = grp.Count()
                                };
    foreach (var item in counts)
        Console.WriteLine("{0} ({1})", item.Value, item.Count);
