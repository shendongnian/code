    public static void ReadNumbers()
    {
        string[] lines = File.ReadAllLines("text.TXT");
        // timeSlots[i] - how many members are registered in i-th time slot
        // 4 is number of time slots minus 1 (we skip the 0th element for convenience)
        int[] timeSlots = new int[4]; 
        var groups = lines
            .Where(line => line.StartsWith("Time"))
            .Select(line => Int32.Parse(new string(line.Where(Char.IsDigit).ToArray())))
            .GroupBy(number => number);
        foreach (var group in groups)
        {
            // group.Key - occupied time slot number
            // group.Count() - how many members in the occupied time slot
            if (group.Key < timeSlots.Count())
            {
                timeSlots[group.Key] = group.Count();
            }
        }
        for (int i = 1; i < timeSlots.Count(); i++)
        {
            Console.WriteLine($"Time slot {i} appeared: {timeSlots[i]} times");
        }
                
    }
