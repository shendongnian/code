    static void Main()
    {
        var size = sizeof(int);
        Console.WriteLine($"int size:{size}");
        size = sizeof(bool);
        Console.WriteLine($"bool size:{size}");
        size = sizeof(double);
        Console.WriteLine($"double size:{size}");
        size = sizeof(char);
        Console.WriteLine($"char size:{size}");
    }
