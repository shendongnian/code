    void Main()
    {
        dynamic i = int.MaxValue - 10;
        i += 15;
        Console.WriteLine(i.GetType());
        Console.WriteLine(i);
    }
