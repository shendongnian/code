    Console.WriteLine("Please enter a number between 1 and 9:");
    while (true)
    {
        int maxValue = 1;
        if (!int.TryParse(Console.ReadLine(), out maxValue) || maxValue < 1 || maxValue > 9)
        {
            Console.WriteLine("Wrong input! Try again:");
            continue;
        }
        break;
    }
    while (i <= maxValue)
