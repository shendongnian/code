    public static void Main(string[] args)
    {
        int x = 0;
        new Thread(() => {while(x != 100){Console.WriteLine(x);}}).Start();
        for(int i = 0; i != 100; ++i)
        {
            x = i;
            Thread.Sleep(10);
        }
        x = 100;
        Console.ReadLine();
    }
