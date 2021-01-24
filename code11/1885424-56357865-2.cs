    // External method returning a Task
    public Task<int> DoFooAsync(object myParam);
    
    public bool ParseMyFoo(Func<Task<int>> myTask) {
        var result = myTask();
    
        if (result == 0xbadbeef || result == 0xf00dbabe) {
            Console.WriteLine("Schrödingers takeaway");
        }
    }
    
    public static void Main(string[] args) {
        Console.WriteLine("Assesment: {0}", ParseMyFoo(DooFooAsync(Console.ReadLine()));
    }
