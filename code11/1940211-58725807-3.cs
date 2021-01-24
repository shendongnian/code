    var result = list
        .GroupAdjacent(item => item.Status)
        .Select(grp => new SubItem
        {
            Status = grp.Key,
            Value = string.Concat(grp.Select(item => item.Value))
        });
                
    foreach (var item in result)
    {
        Console.WriteLine(item.ToString());
    }
