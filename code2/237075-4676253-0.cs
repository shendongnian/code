    for (int row = 0; row < peak; row++)
    {
        Console.WriteLine(new string(character, row + 1));
    }
    for (int row = 1; row < peak; row++)
    {
        Console.WriteLine(new string(character, peak - row));
    }
