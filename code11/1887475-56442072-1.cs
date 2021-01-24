var t = new Task(async () => await AsyncTest());
Look at the signature of `Task` constructors:
    
    	public Task(Action action);
    	public Task(Action action, CancellationToken cancellationToken);       
    	public Task(Action action, TaskCreationOptions creationOptions);
    	public Task(Action<object> action, object state);
    	public Task(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
    	public Task(Action<object> action, object state, CancellationToken cancellationToken);
    	public Task(Action<object> action, object state, TaskCreationOptions creationOptions);
    	public Task(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
All of them are `Actions` and as you know `Action` has `void` return type.
    static async Task Main(string[] args)
    {
        // best way to do it
        await AsyncTest();
        
        Console.WriteLine("Main finished");
    }
    
    private static async Task AsyncTest()
    {
        // Don't use thread sleep, await task delay is fine
        // Thread.Sleep(2000);
        await Task.Delay(2000);
        Console.WriteLine("Method finished");
    }
  [1]: https://stackoverflow.com/questions/38241875/task-wait-not-waiting-for-task-to-finish/38241969#38241969
