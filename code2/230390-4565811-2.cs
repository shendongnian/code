    List<int> numbers = new List<int> {5, 4};
    IEnumerable<int> first = numbers.Take(1);
    Console.WriteLine(first.Single()); //prints 5
    numbers.Sort();
    Console.WriteLine(first.Single()); //prints 4!
