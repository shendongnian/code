	public static void Main()
	{
		string input = "8:30";
		float output = ParseTimeAsDecimal(input);
		Console.WriteLine(output);
	}
	
	public static float ParseTimeAsDecimal(string time)
	{
		DateTime d = DateTime.ParseExact(time, "H:mm", CultureInfo.InvariantCulture);
		int hours = d.Hour;
		int minutes = d.Minute;
		float minutesFraction = minutes / 60f;
		return ((float)hours) + minutesFraction;
	}
