    public interface ISomething
    {
    	ISomething Clone();
    }
    
    public abstract class Something : ISomething 
    {
    	protected abstract ISomething CloneInternal();
    	
    	ISomething ISomething.Clone()
    	{
    		return CloneInternal();
    	}
    }
    
    public abstract class Something<T>: Something, ISomething where T: ISomething, new()
    {
    	protected override ISomething CloneInternal()
    	{
    		return Clone();
    	}
    	
    	public abstract T Clone();
    }
    
    public class ActualThing: Something<ActualThing>, IActualThing
    {
    	public override ActualThing Clone() 
    	{
    	}
    }
