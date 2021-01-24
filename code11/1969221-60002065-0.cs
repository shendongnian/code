cs
public static IEnumerable<string> GetDays(bool isHolidayWeek)
{
	var days = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
	if (isHolidayWeek)
		return days.Select(d => $"{d} Holiday");
	return days;
}
