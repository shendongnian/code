    public enum runAsync {
        No = 0,
        Yes =1
    }
    
    public static async void PrintToConsole(string inVal, runAsync method = runAsync.No)
    {
        if (method == runAsync.Yes)
        {
            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(
                () => Thread.Sleep(3000)
            );
            task.Start();
            await task;                
        }            
        Console.WriteLine(inVal);
    }
            
    static void Main(string[] args) {
    
        Console.WriteLine("Async: Started");
        PrintToConsole("Async: Finished!", runAsync.Yes);
        Console.WriteLine("Sync: Started");
        PrintToConsole("Sync: Finished!");
        Console.ReadLine();
    
    
        return;
    }
