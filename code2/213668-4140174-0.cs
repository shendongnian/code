    HashSet hashset = new HashSet();
    using (var file = new StreamReader(path))
    {
        string line;
        while ((line = file.ReadLine()) != null)
            hashset.Add(line);
    }
    // ...
    if (hashset.Contains(selection))
    {
        i = (int)Choice.GoodChoice;
        Console.WriteLine("You chose " + selection + " radio!");
    }
    else
    {
        switch (selection)
        {
        case "!exit":
        case "!!":
            i = (int)Choice.ExitChoice;
            break;
        case "!info":
            TitleScreen();
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        default:
            Console.WriteLine("Invalid selection! Please try again!");
            break;
        }
    }
