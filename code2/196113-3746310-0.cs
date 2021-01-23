    IEnumerable<int> a = new int[] { 1, 2, 5 };
    IEnumerable<int> b = new int[] { 2, 3, 5 };
    foreach (int x in a.Except(b))
    {
        Console.WriteLine(x);  // prints "1"
    }
