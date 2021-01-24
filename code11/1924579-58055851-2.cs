	public enum DaysOfWeek
	{
		Sunday = 0,
		Monday = 1,
		Tuesday = 2,
		Wednesday = 3,
		Thursday = 4,
		Friday = 5,
		Saturday = 6
	}
	
    int dayVal = 2;
    if (Enum.IsDefined(typeof(DaysOfWeek), dayVal)) // check it's in the enum
    {
        var dayOfWeek = (DaysOfWeek)dayVal;
        Console.WriteLine($"Today is {dayOfWeek}."); // this will print the name corresponding to the enum value
    }
	
