    var query =
        from c in arrayList
        group c by c into g
        where g.Count() > 1
        select new { Item = g.Key,  ItemCount = g.Count()};
    
    foreach (var item in query)
    {
        Console.WriteLine("Country {0} has {1} cities", item.Item , item.ItemCount );
    }
