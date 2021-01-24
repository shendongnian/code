    var strings = new List<string> { "1 2 4.5 72", "1 7..5 3.2.1" };
    foreach (var item in strings)
    {
        if (item.Split(" ").All(str => double.TryParse(str, out var result)))
        {
            Console.WriteLine($"{item} has valid numbers");
        } else
        {
            Console.WriteLine($"{item} does not have valid numbers");
        }
    }
    // 1 2 4.5 72 has valid numbers
    // 1 7..5 3.2.1 does not have valid numbers
