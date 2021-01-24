    int count = 0;
    double total = 0;
    Console.Write("Enter your number: ");
    int input = int.Parse(Console.ReadLine());
    while (input != 0)
    {
        count++;
        if (count % 5 == 1)
            total = total + input;
        Console.Write("Enter your number: ");
        input = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("The sum of every +5 numbers is: {0}", total);
    Console.ReadKey();
