    bool correctInput = false;
    while (!correctInput) // this loop will continue until the user enters a number
    {
        Console.Write("Enter Year: ");
        correctInput = int.TryParse(Console.ReadLine(), out year); // if the parsing was successful it returns true
        if (!correctInput)
        {
            Console.Write("Your input was not a number");
        }
    }
