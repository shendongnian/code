    public async Task hello()
    {
        Console.WriteLine("some task");
        await Task.Delay(1000);
        Console.WriteLine("after some time");
    }
    public static async Task Main(string[] args) 
    {
      Input std1 = new Input( );
      await std1.hello();
    }
