    for (int i = int.MaxValue; i > 0; i--)
    {
        try
        {
            byte[] b = new byte[i];
            Console.Out.WriteLine("MaxValue: " + i);
            Environment.Exit(0);
        }
        catch (Exception ignored)
        {}
    }
