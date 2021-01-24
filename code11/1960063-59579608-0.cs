    public class TaskInfo
    {
    	public string Name { get; set; }
    	public Task Task { get; set; }
    	public CancellationTokenSource Token { get; set; }
    }
    
    // Define other methods and classes here
    public interface IMyClass
    {
    	void Start(string name);
    	void Stop(string name);
    }
    
    public class MyClass : IMyClass
    {
    	private Dictionary<string,TaskInfo> _tasks = new Dictionary<string,TaskInfo>();
    
    	public void Start(string name)
    	{
    		if(_tasks.ContainsKey(name)) 
    			throw new Exception($"Task with name {name} already exists");
    		
    		CancellationTokenSource cts = new CancellationTokenSource();
    		TaskInfo taskInfo = new TaskInfo() {
    			Token = cts,
    			Name = name,
    			Task = Task.Factory.StartNew(() => DoWork(name, cts.Token))
    		};
    			
    		_tasks.Add(name,taskInfo);
    	}
    
    	public void Stop(string name)
    	{
    		if (_tasks.ContainsKey(name)) {
    			_tasks[name].Token.Cancel();
    		}
    	}
    
    	public void DoWork(string name, CancellationToken token)
    	{
    		try
    		{
    			while (true)
    			{
    				Console.WriteLine($"{name} is working");
    
    				// long operation...
    				Thread.Sleep(1000);
    
    				if (token.IsCancellationRequested)
    				{
    					Console.WriteLine($"{name} canceled");
    					token.ThrowIfCancellationRequested();
    				}
    			}
    		}
    		catch (OperationCanceledException ex)
    		{
    			Console.WriteLine(ex.Message);
    		}
    	}
    }
