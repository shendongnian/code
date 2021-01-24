        Console.Write("Please type your number here:");
        if(!Int32.TryParse(Console.ReadLine(), out num))
            Console.WriteLine("Invalid number");
        if (num < 0)
            Console.WriteLine("This is a negative number!");
        if (num > 0)
            Console.WriteLine("This number is a positive number");
