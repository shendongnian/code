    public interface IDateTimeProvider
    {
    	DateTime CurrentDateTime { get; }
    }
    
    public class DateTimeProvider : IDateTimeProvider
    {
    	public DateTime CurrentDateTime
    	{
    		get { return DateTime.Now; }
    	}
    }
    
    public class TestDateTimeProvider : IDateTimeProvider
    {
    	public DateTime CurrentDateTime { get; set; }
    }
    
    public class Scheduler
    {
    	private readonly IDateTimeProvider DateTimeProvider;
    	
    	public Scheduler(IDateTimeProvider provider)
    	{
    		DateTimeProvider = provider;
    	}
    }
