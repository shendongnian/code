    bool isValidInt = int.TryParse(Console.ReadLine(), out int userAge);
    if (!isValidInt)
    {
        //False user input...
        Console.WriteLine($"Input is wrong. Exiting program ...")
        return;
    }
