    for (int i = 0; i < 50; i++)
    {
        Console.Clear();
        Console.Write("Waiting for {0} seconds\r", i);
        System.Threading.Thread.Sleep(1000);
    }
