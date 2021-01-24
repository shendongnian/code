    public static async Task Main(string[] args)
    {
        var t = Task.Factory.StartNew(async () => await AsyncTest());
    	//t.Start();
    	t.Result.Wait();    
        t.Wait();
        Console.WriteLine("Main finished");
    }
    
    private static async Task AsyncTest()
    {
        //Thread.Sleep(2000);
        await Task.Delay(2000);
        Console.WriteLine("Method finished");
    }
