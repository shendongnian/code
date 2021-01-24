        var numbers = new List<int>();
        Console.Write("Enter your number: ");
        var input = int.Parse(Console.ReadLine());
        numbers.Add(input);
        while (input != 0)
        {
            input = int.Parse(Console.ReadLine());
            numbers.Add(input);
        }
        var total = numbers.Where((x, i) => i % 5 == 0).Sum();
        Console.WriteLine("The sum of every +5 numbers is: {0}", total);
        Console.ReadKey();
