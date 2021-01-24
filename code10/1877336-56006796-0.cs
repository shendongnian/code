    do
    {
        int x, y;
        Console.WriteLine("Enter Hit Coordinates (x,y):");
        var input = Console.ReadLine();
        var parts = input.Split(',');
        if (parts.Length!=2)
        {
            Console.WriteLine("Please enter two values separated by a comma.");
            break;
        }
        if (int.TryParse(parts[0].Trim(), out x) && int.TryParse(parts[1].Trim(), out y))
        {
            // use the x, y values below
            Console.WriteLine($"User input was: ({x},{y})");
        }
        else
        {
            Console.WriteLine("Please enter numeric values.");
        }
    }
    while (true);
