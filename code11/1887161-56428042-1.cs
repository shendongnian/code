	public enum Status
	{
		NotStarted = 0,
		Started = 1,
		InProgress = 2,
		Declined = 3
	}
	public static void Main()
	{
		var curStatus = Status.NotStarted;
		
		Console.WriteLine(curStatus.ToString()); //writes 'NotStarted'
		
		if ((int)curStatus++ == (int)Status.Started)
		{
			curStatus = Status.Started;	
		}
		Console.WriteLine(NextState(curStatus)); //writes 'InProgress'
	}
