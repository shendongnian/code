    int n;
    Console.Write("Enter n amount of lines/columns: ");
    n = int.Parse(Console.ReadLine());
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < i + 1; j++)
            Console.Write(j + 1);
        for (int j = i + 1; j < n; j++)
            Console.Write(i + 1);
        Console.WriteLine();
    }
    Console.ReadKey();
