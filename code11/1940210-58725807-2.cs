    var result = list
        .GroupAdjacent(item => item.Status)
        .Select(grp => new SubItem
        {
            Status = grp.Key,
            Value = string.Join("", grp.Select(x => x.Value))
        });
                
    foreach (var item in result)
    {
        Console.WriteLine(item.ToString());
    }
