	public class DateTimeToDateMapping : IAutoMapperInitializer
	{
		public void Initialize(IConfiguration configuration)
		{
			configuration.CreateMap<DateTime, Date>().ConstructUsing(
				dateTime => new Date(dateTime.Year, dateTime.Month, dateTime.Day));
		}
	}
