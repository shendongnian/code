    public class Model
    {
	    public long time {get;set;}
	
	    public DateTime datetime 
	    {
		   get
		   {
			   return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
    			  .AddMilliseconds(time)
    			  .ToLocalTime();
		   }
	    }	
     }
