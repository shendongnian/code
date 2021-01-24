    List<double> nums = new List<double> { 0.2, 5.0, 12.0 };
    var index = nums.Select((d, i) => new {index = i, value = d - d * d})
        .OrderByDescending(x => x.value)
        .Take(1)
        .Select(x => (int?) x.index)
        .FirstOrDefault();
    if (index == null)
        Console.WriteLine("nums is empty");
    else
        Console.WriteLine($"index is {index}");
