    int choice = 0;
    do
    {
        Console.WriteLine("Select a search method.");
        Console.WriteLine("1. Binary Search");
        Console.WriteLine("2. Linear Search");
        Console.WriteLine("3. Bubble Sort");
        Console.WriteLine("99. Exit");
        Console.Write("Enter your choice number: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out choice))
        {
            switch (choice)
            {
                case 99:
                    break;
                case 1:
                    // Call Binary Search
                    break;
                case 2:
                    // Call Linear Search
                    break;
                case 3:
                    // Call Bubble Sort
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid choice.");
        }
    } while (choice != 99);
