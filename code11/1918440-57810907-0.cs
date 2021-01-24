    static void Main()
    {
        //var inputs = new [] { 40, 8, 16, 6 }; // total = 114
        var inputs = new[] { 62, 14, 2, 6, 28, 41 }; // total = 324
        var total = 0;
        var query = inputs.AsEnumerable();
        while (query.Count() > 1)
        {
            // sort the numbers
            var sorted = query.OrderBy(x => x).ToList();
            // get sum of the first two smallest numbers
            var sumTwoSmallest = sorted.Take(2).Sum();
            // count total
            total += sumTwoSmallest;
            // remove the first two smallest numbers
            query = sorted.Skip(2);
            // add the sum of the two smallest numbers into the numbers
            query = query.Append(sumTwoSmallest);
        }
        Console.WriteLine($"Total = {total}");
        Console.WriteLine("Press any key...");
        Console.ReadKey(true);
    }
