    myEnumerable = myEnumerable.Memoize();
    Console.WriteLine("");
    Console.WriteLine("Starting");
    myEnumerable.First();
    Console.WriteLine("");
    myEnumerable.Skip(1).First();
