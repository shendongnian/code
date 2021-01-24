    static class Ext
    {
    	public static DateTime Add(this DateTime one, DateTime two)
        {
            return new DateTime(one.Ticks + two.Ticks);
        }
    }
