    var source = new List<(int Id, DateTime DueDate)>();
    source.Add((1, new DateTime(2020, 1, 1, 1, 30, 0)));
    source.Add((2, new DateTime(2020, 1, 1, 1, 40, 0)));
    source.Add((3, new DateTime(2020, 1, 1, 3, 20, 0)));
    source.Add((4, new DateTime(2020, 1, 1, 4, 10, 0)));
    source.Add((5, new DateTime(2020, 1, 1, 5, 10, 0)));
    var groups = source
        .OrderBy(x => x.DueDate)
        .GroupConsecutive((item, group) =>
            (item.DueDate - group[0].DueDate).Duration().TotalMinutes <= 60);
    foreach (var group in groups)
    {
        Console.WriteLine($"Group: {String.Join(", ", group)}");
    }
