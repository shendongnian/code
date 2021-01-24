    public static void Main(string[] args)
    {
        var worker = new Worker<string>
        {
            Interval = 1000,
            Func = () => { return string.Format("did some work at {0}", DateTime.Now); }
        };
        worker.OnCompleted += (sender, result) => { Console.WriteLine(result); };
        worker.Start();
        Console.ReadLine();
    }
