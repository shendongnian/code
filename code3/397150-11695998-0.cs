    // An immutable command, to be handled in-process.  
    // ICommand is a marker interface with no members.
    public class DoSomething : ICommand 
    {
    	public readonly Id;
    
    	public DoSomething(Guid id)
    	{
    		Id = id;
    	}
    }
    
    // To be handled out-of-process.
    [AsynchronousCommand]
    public class DoSomethingThatTakesAReallyLongTime : ICommand
    {
    	public readonly Id;
    
    	public DoSomethingThatTakesAReallyLongTime(Guid id)
    	{
    		Id = id;
    	}
    }
    
    // This guy could take any number of dependencies: ISomethingRepository, DbContext, etc.
    // Doesn't matter, but it's probably gonna have dependencies.
    public class DoSomethingHandler : IHandler<DoSomething> 
    {
    	public void Handle(DoSomething command) // IHandler<T>'s only member
    	{
    		// CRUD or call call a domain method
    	}
    }
    
    public class CommandService : ICommandService
    {
    	public void Execute(params ICommand[] commands) // ICommandService's only member
    	{ 
    		foreach(var command in commands)
    		{
    			var handler = GetHandler(command); // Could use your IOC container.
    
    			if (HasAsyncAttribute())
    				new Action(() => handler.Handle(command)).BeginInvoke(null, null);
    			else
    				handler.Handle(command);
    		}
    	} 
    }
    
    // Something that might consume these
    public class SomethingController
    {
    	private readonly ICommandService _commandService;
    
    	public SomethingController(ICommandService commandService)
    	{
    		_commandService = commandService;
    	}
    
    	[HttpPost]
    	public void DoSomething(Guid id)
    	{
    		_commandService.Execute(new DoSomething(id));
    	}
    
    	[HttpPost]
    	public void DoSomethingThatTakesAReallyLongTime(Guid id)
    	{
    		_commandService.Execute(new DoSomethingThatTakesAReallyLongTime(id));
    	}
    }
