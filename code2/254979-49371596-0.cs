    using System;
    using System.Diagnostics;
    
    namespace HQ.Util.General
    {
    	public static class StopWatchExtension
    	{
    		public static TimeSpan ToTimeSpan(this Stopwatch stopWatch)
    		{
    			return TimeSpan.FromTicks(stopWatch.ElapsedTicks);
    		}
    	}
    }
