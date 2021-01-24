    // Target List Which you will get as a result
    List<int> Targets = new List<int>();
    Targets.AddRange(new int[] { 4200, 5200, 6200, 7200, 9200, 11200, 11700, 15300, 17200, 20000, 23000, 25200 });
    // Target value which you will check
    int InputNo = 4329;
    // Region for Round
    {
        // This print 4200 for 4329
        // and 15300 for 15400
        // Check differences between Targets' elements and InputNo
        List<int> Diffs = Targets.Select(x => Math.Abs(x - InputNo)).ToList();
        int index = Diffs.IndexOf(Diffs.Min());
        // Print Result
        Console.WriteLine("Round Result => " + Targets[index]);
    }
    // Region for Round Up
    {
        int Result = -1;
        try
        {
            Result = Targets.Where(x => (x >= InputNo)).First();
        }
        catch
        {
            Result = Targets.Max();
        }
        // This prints Round up values.
        // if InputNo is bigger than any Elements, it'll be return Max values of elements
        Console.WriteLine("Round Up Result => " + Result);
    }
