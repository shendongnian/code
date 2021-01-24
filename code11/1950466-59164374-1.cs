    using (var reader = new StreamReader("input.txt"))
    {
        string na = "N/A";
        string line;
        for (var i = 0; i < 4; i++)
        {
            var isAvailable = reader.TryReadNextLine(out line);
            Console.WriteLine($"Next line available: {isAvailable}. Line: {(isAvailable ? line : na)}");
        }
        for (var i = 0; i < 4; i++)
        {
            var isAvailable = reader.TryReadPrevLine(out line);
            Console.WriteLine($"Prev line available: {isAvailable}. Line: {(isAvailable ? line : na)}");
        }
    }
