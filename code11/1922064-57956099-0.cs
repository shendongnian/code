    while(userInputInt2 != 2 && userInputInt2 != 1)
    {
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("--INVALID OPTION SELECTED                      --");
        Console.WriteLine("--Please Select an Option Below                --");
        Console.WriteLine("--Return To Main Menu (1)                      --");
        Console.WriteLine("--Exit                (2)                      --");
        Console.WriteLine("-------------------------------------------------");
        Console.Write("--Selected Option: ");
        userInput = Console.ReadLine();
        userInputInt2 = Int32.Parse(userInput);
    }
