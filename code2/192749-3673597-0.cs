    while (response == 'A'){
        Console.WriteLine("Enter Sales");
        string salesStr = Console.ReadLine();
        Console.WriteLine(Double.Parse(salesStr) * COMMRATE);
        Console.WriteLine("Enter A to continue, anything else to quit");
        response = Convert.ToChar(Console.ReadLine());
    }
