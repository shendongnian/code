    public static void ReadNumbers()
    {
        string[] lines = File.ReadAllLines("text.TXT");
    
        var timeSlots = lines.Where(line => line.StartsWith("Time"))
            .Select(line => Int32.Parse(new string(line.Where(Char.IsDigit).ToArray())));
    
        int timeSlotOneCount = 0;
        int timeSlotTwoCount = 0;
        int timeSlotThreeCount = 0;
        foreach (var timeSlot in timeSlots)
        {
            if (timeSlot == 1) timeSlotOneCount++;
            else if (timeSlot == 2) timeSlotTwoCount++;
            else if (timeSlot == 3) timeSlotThreeCount++;
        }
    
        Console.WriteLine($"Total Member Registered for Slot 1: {timeSlotOneCount}");
        Console.WriteLine($"Total Member Registered for Slot 2: {timeSlotTwoCount}");
        Console.WriteLine($"Total Member Registered for Slot 3: {timeSlotThreeCount}");
    }
