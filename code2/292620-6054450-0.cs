    var list1 = new List<Foo>();
    using (var rdr1 = cmd1.ExecuteReader())
    {
        list1.Add(...);
    }
    var list2 = new List<Bar>();
    var cmd2 = ...;
    foreach (var item in list1)
    {
        // assign parameters to cmd2 from item
        using (var rdr2 = cmd2.ExecuteReader())
        {
            list2.Add(...);
        }
    }
