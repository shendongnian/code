    var elements = new List<int>();
    var sum = SumOfEvenNumbersInRange(7, 13, elements);
    
    if (elements.Count == 0)
    {
        elements.Add(0);
    }
    Console.WriteLine($"{string.Join(" + ", elements)} = {sum}");
