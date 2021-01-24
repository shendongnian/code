    public static void Run1() {
        DoStuffAsync();
        Console.WriteLine("Done");
    }
    
    public static async Task Run2() {
        await DoStuffAsync();
        Console.WriteLine("Done");
    }
