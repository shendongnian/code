    int n = 5;
    
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n - i; j++)
        {                 //^^^^^ n - i is key behind this * pattern
            Console.Write("*");
        }
        Console.WriteLine(Environment.NewLine);
    }
