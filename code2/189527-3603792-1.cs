    int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    try
    {
        var fragment = new ArrayFragment<int>(numbers, 2, 5);
        Console.WriteLine("Iterating using foreach: ");
        foreach (int number in fragment)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine("Iterating using for: ");
        for (int i = 0; i < fragment.Count; ++i)
        {
            Console.WriteLine(fragment[i]);
        }
        Console.WriteLine("Index of 4: {0}", fragment.IndexOf(4));
        Console.WriteLine("Index of 1: {0}", fragment.IndexOf(1));
        Console.WriteLine("Index of 9: {0}", fragment.IndexOf(9));
        Console.WriteLine("Index of 7: {0}", fragment.IndexOf(7));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    Console.ReadLine();
