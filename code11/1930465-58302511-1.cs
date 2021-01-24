    var numbers = new List<int>();
    Console.Write("Enter your number: ");
    var input = int.Parse(Console.ReadLine());
    while (input != 0)
    {
    	numbers.Add(input);
        input = int.Parse(Console.ReadLine());
    }
    var total = numbers.Where((x, i) => i % 5 == 0).Sum();
    Console.WriteLine("The sum of every +5 numbers is: {0}", total);
