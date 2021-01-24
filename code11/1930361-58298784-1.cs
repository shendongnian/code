    ...
    //Store all i's in list
    List<int> numbers = new List<int>(); 
    for (int i = 1; i <= n; i++)
    { 
        if (i % 3 == 0 || i % 5 == 0)
            numbers.Add(i);
    }
    Console.Write(string.Join(", ", numbers));
    ...
