    public interface IDateTime
    {
    	DateTime Now();
    }
    
    public class Foo
    {
    	IDateTime dt;
    
    	public DateTime GetActualTime
    	{
    		get
    		{
    			return dt.Now();
    		}
    	}
    
    	public Foo(IDateTime dt)
    	{
    		this.dt = dt;
    	}
    
    	public string Bar()
    	{
    		return this.GetActualTime().ToString();
       }
    }
