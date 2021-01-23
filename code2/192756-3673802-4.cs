    string salesStr;
    if (response == 'A')
    {
        Console.WriteLine("Enter amount of sales");
        salesStr = Console.ReadLine();
    }
    
    if (response == 'B')
    {
        Console.WriteLine("Enter amount of sales");
        salesStr = Console.ReadLine();
    }
    
    if (response == 'E')
    {
        Console.WriteLine("Enter amount of sales");
        salesStr = Console.ReadLine();
    }
    Console.WriteLine(Double.Parse(salesStr) * COMMRATE);
    Console.WriteLine("Enter sales member to continue or Z to exit");
    response = Convert.ToChar(Console.ReadLine());
