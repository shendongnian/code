	public enum TimeUnit
	{
		Milliseconds,
		Second,
		Minute,
		Hour,
		Day,
		Week
	}
	public class TimeConverter : UnitConverter<TimeUnit, double>
	{
		static TimeConverter()
		{
			BaseUnit = TimeUnit.Second;
			RegisterConversion(TimeUnit.Milliseconds, 1000);
			RegisterConversion(TimeUnit.Minute, 1/60);
			RegisterConversion(TimeUnit.Hour, 1/3600);
			RegisterConversion(TimeUnit.Day, 1/86400);
			RegisterConversion(TimeUnit.Week, 1/604800);
		}
	}
