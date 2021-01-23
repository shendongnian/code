    public static class ExtensionMethods
    {
       static IEnumerable<DateTime> GetDateRange(this DateTime d, DateTime e)
       {
    	    var t=d;
    	    do
    	    {
                yield return t;
                t=t.AddDays(1);
            }while(t<e);
        }
    }
