    static void Main(string[] args)
    {
        var info = DummyInfoGameWindow.InitAndGetInfo();
        Console.WriteLine($"VSync enabled {info.VSync}");
        Console.Read();
    }
