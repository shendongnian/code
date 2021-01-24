    static class Ext
    {
    	public static DateTime HalfWayTo(this DateTime one, DateTime two)
        {
            return new DateTime(Math.Abs(one.Ticks + two.Ticks)/2);
        }
    }
