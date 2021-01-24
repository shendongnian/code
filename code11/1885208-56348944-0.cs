public static class Extensions
{
    public static IQueryable<TDestination> ProjectToPassUserTimeOffset<TDestination>(this IQueryable<IAuditStampsViewModel> entityQuery)
    {
        return entityQuery.ProjectTo<TDestination>(new {intMinutesOffset=TimeUtilities.UserTimeZoneUTCOffsetMinutes()});
    }
}
The caller would be:
public IQueryable<ItemViewModel> ConvertClassToViewModel(IQueryable<Item> entityQuery)
{
    return entityQuery.ProjectToPassUserTimeOffset<ItemViewModel>();
}
