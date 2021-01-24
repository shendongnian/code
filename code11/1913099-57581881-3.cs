    static async Task simpleAsync()
    {
        int i = await jobAsync();
        Console.WriteLine("Async done. Result: " + i.ToString());
    }
    static Task simpleTask()
    {
        return jobAsync().ContinueWith(i => 
            Console.WriteLine("Async done. Result: " + i.ToString()));
    }
