    List<int> integers = new List<int>();
    integers.Add(5); // No boxing required
    int firstValue = integers[0]; // Random access
    // Iteration
    foreach (int value in integers)
    {
        Console.WriteLine(value);
    }
