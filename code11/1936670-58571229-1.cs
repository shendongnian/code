    for(int j = 2; j <= 4; j++)
    {
        for(int i = 1; i <= 20; i++)
        {
            if (i % j == 0)
                Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
