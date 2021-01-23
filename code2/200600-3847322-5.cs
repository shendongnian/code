    int[] numbers = new[] { 21, 4, 7, 9, 12, 22, 17, 8, 2, 20, 23 };
    foreach (Range r in FindConsecutiveRanges(numbers, 3))
    {
        // Using .NET 3.5 here, don't have the much nicer string.Join overloads.
        Console.WriteLine(string.Join(", ", r.Select(x => x.ToString()).ToArray()));
    }
