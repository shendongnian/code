public class EventOrganizerProviders : IModelBinderProvider
{
	public IModelBinder GetBinder(Type modelType)
	{
		if (modelType == typeof(DateTime))
		{
			return new DateTimeBinder();
		}
                // Other types follow
		if (modelType == typeof(TimeSpan?))
		{
			return new TimeSpanBinder();
		}
		return null;
	}
}
