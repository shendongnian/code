    bool isValidDimension;
    do
    {
        Console.Write("Dimension: ");
    
        string input = Console.ReadLine();
    
        isValidDimension = int.TryParse(input, out dimension);
    
        if (!isValidDimension)
        {
            Console.WriteLine("Invalid dimension... please try again.");
            Console.WriteLine();
        }
    } while (!isValidDimension);
