    public enum runAsync {
        No = 0,
        Yes =1
    }
    
    public static async Task PrintToConsole(string inVal, runAsync method = runAsync.No)
    {
        if (method == runAsync.Yes)
        {
            await Task.Dealy();                
            Console.WriteLine(inVal + "async");
        }            
        else
        {
             Console.WriteLine(inVal + "sync");
        }
    }
            
    static async Task Main(string[] args) {
    
        Console.WriteLine("Async: Started");
        await PrintToConsole("Async: Finished!", runAsync.Yes);
        Console.WriteLine("Sync: Started");
        PrintToConsole("Sync: Finished!");
        Console.ReadLine();
    
    
        return;
    }
