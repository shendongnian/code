    int i, j, n;
    Console.WriteLine("Enter size: ");
    n = int.Parse(Console.ReadLine());
    for (i = 0; i < n; i++)
    {
        for (j = 1; j <= n - i; j++)
            Console.Write(" ");
        for (j = 1; j <= 2 * i - 1; j++)
            Console.Write("*");
        Console.Write("\n");
    }
