    void Main()
    {
    	var periods = new[] {
    		new TimeSpan(0, 10, 0),
    		new TimeSpan(0, 10, 0),
    		new TimeSpan(0, 10, 0),
    	};
    	TimeSpan total = periods.Sum();
    	TimeSpan total2 = periods.Sum(p => p);
    	
    	Debug.WriteLine(total);
    	Debug.WriteLine(total2);
        // output: 00:30:00
        // output: 00:30:00
    }
    
    
    public static class LinqExtensions
    {
    	public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpanCollection)
    	{
    		return timeSpanCollection.Sum(s => s);
    	}
    
    	public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> func)
    	{
    		return new TimeSpan(source.Sum(item => func(item).Ticks));
    	}
    }
