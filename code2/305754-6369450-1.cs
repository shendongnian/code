    var query = myTable.AsEnumerable();
    // Assuming there is one value at least.
    var first = query.First().Field<string>("ColorCode");
    if (query.Any(a => a.Field<string>("ColorCode") != first))
    {
        throw new Exception();
    }
