    public class Ticker
    {
    	public event EventHandler Tick;
    	public EventArgs e = null;
    	public void TickIt()
    	{
    		const int targetSleepTime = 300;
    		int nextTick = Environment.TickCount + targetSleepTime;
    		while (true)
    		{
    			System.Threading.Thread.Sleep(Math.Max(nextTick - Environment.TickCount, 0));
    			if (Tick != null)
    			{
    				Tick(this, e);
    			}
    			nextTick += targetSleepTime;
    		}
    	}
    }
