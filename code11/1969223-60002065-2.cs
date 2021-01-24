cs
public static readonly IList<string> Days = new List<string>()
	{"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
public static IEnumerable<string> GetDays(bool isHolidayWeek)
{
	if (isHolidayWeek)
		return Days.Select(d => $"{d} Holiday");
	return Days;
}
