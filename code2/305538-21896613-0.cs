    var seq = table.AsEnumerable().Select(row => (dynamic)new DynamicDataRow(row));
    foreach (var s in seq)
    {
        Console.WriteLine(s.Column1);
        Console.WriteLine(s.Column2);
        Console.WriteLine(s.Column3);
    }
