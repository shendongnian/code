    int lineCount = 0;
    for (int i = 1; i < 11; i++)
    {
        lineCount += File.ReadLines(@i + ".txt").Count();
    }
    Console.WriteLine("Total IDs: " + lineCount);
