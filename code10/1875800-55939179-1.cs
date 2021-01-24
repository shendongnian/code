    public class DateTimeTest : IDateTime
    {
    	DateTime dt;
    	public DateTimeTest(DateTime testTime)
    	{
    		this.dt = testTime;
    	}
    	
    	public DateTime Now()
    	{
    		return dt;
    	}
    }
