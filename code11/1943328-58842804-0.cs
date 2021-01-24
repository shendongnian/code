// Unit Test Class
[TestClass]
public class UnitTest1
{
	[TestMethod]
	public void C58840237T01()
	{
		DateTime firstDay = new DateTime(2019, 10, 31, 0, 0, 0);
		DateTime lastDay = new DateTime(2019, 11, 1, 0, 0, 0);
		double totalMinutesBusinessIsClosed = C58840237.MinutesBusinessIsClosed(firstDay, lastDay);
		Assert.IsTrue(totalMinutesBusinessIsClosed == 480);
	}
}
// Sample Class
public class C58840237
{
	public static double MinutesBusinessIsClosed(DateTime firstDay, DateTime lastDay)
	{
		double t = 0;
		// Holiday 01
		var h01Start = Convert.ToDateTime("11/01/2019 08:00:00");
		var h01End = Convert.ToDateTime("11/01/2019 16:00:00");
		// Holiday is in range
		if (firstDay <= h01Start && h01Start >= lastDay)
		{
			return (h01End - h01Start).TotalMinutes;
		}
		return t;
	}
}
EDIT: I realize our date time formats are different, but that's easily adjustable.
