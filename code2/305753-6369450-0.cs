    var query = myTable.AsEnumerable();
    // Assuming there is one value at least.
    var first = query.First().ColorCode;
    if (query.Any(a => a.ColorCode != first))
    {
        throw new Exception();
    }
