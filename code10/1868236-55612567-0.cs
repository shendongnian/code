Mapper.Initialize(configuration =>
{
    configuration.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
    configuration.CreateMap<string, DateTime>().ConvertUsing(s => new DateTimeTypeConverter().Convert(s));
    configuration.CreateMap<string, bool>().ConvertUsing(s => Convert.ToBoolean(s));
    configuration.CreateMap<string, decimal>().ConvertUsing(s => Convert.ToDecimal(s));
    configuration.CreateMap<SourceModel, DestinationModel>()
        .ForMember("_CUSTOM_Mynumber", opt => opt.MapFrom(src => src.CustomFieldValues.FirstOrDefault(x => x.Name == "_CUSTOM_Mynumber").Value));
});
The example above shows how we can convert `int`, `bool`, and `decimal`. For `DateTime`, we'll use `ITypeConverter`.
public interface ITypeConverter<in TSource, TDestination>
{
    TDestination Convert(TSource source);
}
Then define a custom convertion:
public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
{
    public DateTime Convert(source)
    {
        return Convert.ToDateTime(source);
    }
}
  [1]: http://docs.automapper.org/en/stable/Custom-type-converters.html
