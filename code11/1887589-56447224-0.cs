    public class MessageGenerator : IDisposable
    {
    	public MessageGenerator()
    	{
    		Console.WriteLine("To whom it may concern,");
    	}
    	
    	public void Dispose()
    	{
    		Console.WriteLine("Thanks and goodbye.");
    	}
    }
