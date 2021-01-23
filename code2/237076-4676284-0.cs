    for (int row = 0; row < peak; row++)
    {
        Console.WriteLine(new string(character, row + 1));
    }
    for (int row = peak, row > 1; row--)
    {
        Console.WriteLine(new string(character, row));
    }
