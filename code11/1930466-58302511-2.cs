    var numbers = new List<int>();
    Console.Write("Enter your number: ");
    var input = int.Parse(Console.ReadLine());
    while (input != 0)
    {
    	numbers.Add(input);
        input = int.Parse(Console.ReadLine());
    }
    var total = numbers.Where((x, i) => (i + 1) % 5 == 0).Sum(); // i + 1 since indexes are 0-based.
    Console.WriteLine("The sum of every +5 numbers is: {0}", total);
