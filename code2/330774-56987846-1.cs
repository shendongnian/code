    public static class AssertExtensions
    {
    	public static void IsDateToday(this Assert assert, DateTime today)
    	{
    		if (today.Date != DateTime.Now.Date)
    		{
    			throw new AssertFailedException($"Kaboom! Assert failed broo..");
    		}
    	}
    }
