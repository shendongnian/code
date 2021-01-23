    // var first = (from a in arr select a).First();
    var first = arr.First();
    // var last = (from a in arr select a).Last();
    var last = arr.Last();
    // var filtered = (from a in arr where a == 10 select a).First();
    // there are a couple of ways to write this:
    var filtered1 = arr.Where(a => a == 10)
                       .First();
    var filtered2 = arr.First(a => a == 10); // produces the same result but obtained differently
    // now a very complex query (leaving out the type details)
    // var query = from a in arr1
    //             join b in arr2 on a.SomeValue equals b.AnotherValue
    //             group new { a.Name, Value = a.SomeValue, b.Date }
    //                 by new { a.Name, a.Group } into g
    //             orderby g.Key.Name, g.Key.Group descending
    //             select new { g.Key.Name, Count = g.Count() };
    var query = arr1.Join(arr2,
                          a => a.SomeValue,
                          b => b.AnotherValue,
                          (a, b) => new { a, b })
                    .GroupBy(x => new { x.a.Name, x.a.Group },
                             x => new { x.a.Name, Value = x.a.SomeValue, x.b.Date })
                    .OrderBy(g => g.Key.Name)
                    .ThenByDescending(g => g.Key.Group)
                    .Select(g => new { g.Key.Name, Count = g.Count() });
