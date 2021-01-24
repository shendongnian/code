    var input = new[] {12, 12, 12, 12, 12, 17, 17, 17, 17, 12, 12,
        12, 12, 12, 17, 17, 17, 17, 17, 17, 17, 12, 12, 12, 12, 12};
    var results = new List<Tuple<int, int>>();
    var current = new Tuple<int, int>(input[0], 1);
    foreach (var number in input.Skip(1))
    {
        if (current.Item1 == number)
        {
            current = new Tuple<int, int>(number, current.Item2 + 1);
        }
        else
        {
            results.Add(current);
            current = new Tuple<int, int>(number, 1);
        }
    }
    results.Add(current);
