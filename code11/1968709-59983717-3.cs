public class Program
{
	static List<ShouldWork> WorkTimeScheldure;
	public static void Main()
	{
		WorkTimeScheldure = new List<ShouldWork>
		{
			new ShouldWork
			{
				Start = new DateTime(2019, 12, 01, 0, 0, 0),
				Scheldure= new Dictionary<DayOfWeek, TimeSpan>()
				{
					{(DayOfWeek)0,  new TimeSpan(0,0,0)},
					{(DayOfWeek)1,  new TimeSpan(8,0,0)},
					{(DayOfWeek)2,  new TimeSpan(7,0,0)},
					{(DayOfWeek)3,  new TimeSpan(6,0,0)},
					{(DayOfWeek)4,  new TimeSpan(5,0,0)},
					{(DayOfWeek)5,  new TimeSpan(8,0,0)},
					{(DayOfWeek)6,  new TimeSpan(0,0,0)}
				}
			},
			new ShouldWork
			{
				Start = new DateTime(2020, 01, 01, 0, 0, 0),
				Scheldure = new Dictionary<DayOfWeek, TimeSpan>()
				{
					{(DayOfWeek)0,  new TimeSpan(0,0,0)},
					{(DayOfWeek)1,  new TimeSpan(4,0,0)},
					{(DayOfWeek)2,  new TimeSpan(3,0,0)},
					{(DayOfWeek)3,  new TimeSpan(6,0,0)},
					{(DayOfWeek)4,  new TimeSpan(5,0,0)},
					{(DayOfWeek)5,  new TimeSpan(9,0,0)},
					{(DayOfWeek)6,  new TimeSpan(0,0,0)}
				}
			}
		};
		var testValues = new[] {
		
			new DateTime(2019, 12, 01, 0, 0, 0),
			new DateTime(2019, 12, 02, 0, 0, 0),
			new DateTime(2019, 12, 03, 0, 0, 0),
			new DateTime(2019, 12, 04, 0, 0, 0),
			new DateTime(2019, 12, 05, 0, 0, 0),
			new DateTime(2019, 12, 06, 0, 0, 0),
			new DateTime(2019, 12, 07, 0, 0, 0),
			new DateTime(2019, 12, 08, 0, 0, 0),
			
			new DateTime(2020, 01, 01, 0, 0, 0),
			new DateTime(2020, 01, 02, 0, 0, 0),
			new DateTime(2020, 01, 03, 0, 0, 0),
			new DateTime(2020, 01, 05, 0, 0, 0),
			new DateTime(2020, 01, 05, 0, 0, 0),
			new DateTime(2020, 01, 06, 0, 0, 0),
			new DateTime(2020, 01, 07, 0, 0, 0),
			new DateTime(2020, 01, 08, 0, 0, 0),
		};
		foreach (var test in testValues) {
		
			// Perhaps there is many possible, so I took the Last.
			var workingTime = WorkTimeScheldure.Last(x => x.Start <= day);
			//Please handle the case where there is no matching scheludre for this date.
			var houtToWork = workingTime.Scheldure[day.DayOfWeek].Hours;
			Console.WriteLine(
				$"{day.ToShortDateString()} , it's a {day.DayOfWeek}" +
				$" I have to work {houtToWork} Hour{(houtToWork>1?"s":"")}!"
			);
		}
	}
}
Result : 
12/01/2019 , it's a Sunday I have to work 0 Hour!
12/02/2019 , it's a Monday I have to work 8 Hours!
12/03/2019 , it's a Tuesday I have to work 7 Hours!
12/04/2019 , it's a Wednesday I have to work 6 Hours!
12/05/2019 , it's a Thursday I have to work 5 Hours!
12/06/2019 , it's a Friday I have to work 8 Hours!
12/07/2019 , it's a Saturday I have to work 0 Hour!
12/08/2019 , it's a Sunday I have to work 0 Hour!
01/01/2020 , it's a Wednesday I have to work 6 Hours!
01/02/2020 , it's a Thursday I have to work 5 Hours!
01/03/2020 , it's a Friday I have to work 9 Hours!
01/04/2020 , it's a Saturday I have to work 0 Hour!
01/05/2020 , it's a Sunday I have to work 0 Hour!
01/06/2020 , it's a Monday I have to work 4 Hours!
01/07/2020 , it's a Tuesday I have to work 3 Hours!
01/08/2020 , it's a Wednesday I have to work 6 Hours!
