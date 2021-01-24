csharp
public DateTime[] GetNextWednesdays(int count, string startDate)
{
	var start = DateTime.Parse(startDate);		
	var wednesday = start.AddDays(DayOfWeek.Wednesday-start.DayOfWeek);
	start = (wednesday > start) ? wednesday : wednesday.AddDays(7);	
	return Enumerable.Range(0,count).Select(i => start.AddDays(i).Date).ToArray();
}
