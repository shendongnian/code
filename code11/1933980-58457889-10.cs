    public class BaseTime
    {
    	// shared proprties 
    	public DateTime DateTimeUtc { get; set; }
    	public float Source { get; set; }
    	public float MovingAverageFast { get; set; }
    	public float MovingAverageSlow { get; set; }
    	public float RsiFast { get; set; }
    	public float RsiSlow { get; set; }
    
    }
    
    public class Minute : BaseTime
    {
    	// add your custom code for Minute
    	// No need for recreating them, since it's already inherited from the base 
    }
    
    public class Day : BaseTime
    {
    	// add your custom code for Day
    	// No need for recreating them, since it's already inherited from the base 
    }
    
    class Program
    {
    	public static BaseTime[] Minutes;
    
    	public static BaseTime[] Days;
    
    	static void Main(string[] args)
    	{
    		Minutes = Enumerable.Range(1, 10000000).Select(n => (BaseTime) new Minute { Source = n }).ToArray();
    		Days = Enumerable.Range(1, 10000000).Select(n => (BaseTime) new Day { Source = n }).ToArray();
    
    		// Generating data for Minutes
    		GenerateMovingAverage(Minutes, 100, (m, value) => m.MovingAverageFast = value);
    		GenerateRsi(Minutes, 60, (m, value)  => m.RsiFast = value);
    		GenerateRsi(Minutes, 250, (m, value) => m.RsiSlow = value);
    
    		// Generating data for Days
    		GenerateMovingAverage(Days, 8, (d, value)  => d.MovingAverageFast = value);
    		GenerateMovingAverage(Days, 45, (d, value) => d.MovingAverageSlow = value);
    		GenerateRsi(Days, 5, (d, value)  => d.RsiFast = value);
    		GenerateRsi(Days, 21, (d, value) => d.RsiSlow = value);			
    	}
    
    	public static void GenerateMovingAverage(BaseTime[] BaseTimeObjects, int Period, Action<BaseTime, float> setter) 
    	{
    		foreach (var BaseTimeObject in BaseTimeObjects)
    		{
    			setter(BaseTimeObject, BaseTimeObject.Source * Period);
    		}
    	}
    	
    	public static void GenerateRsi(BaseTime[] BaseTimeObjects, int Period, Action<BaseTime, float> setter)
    	{
    		foreach (var BaseTimeObject in BaseTimeObjects)
    		{
    			setter(BaseTimeObject, BaseTimeObject.Source / Period);
    		}
    	}
    			
    }
