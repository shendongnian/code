csharp
public sealed class CsvGenericMap<T> : ClassMap<T>
{
    public CsvGenericMap()
    {
        foreach (var property in typeof(T).GetProperties())
        {
            var attribute = property?.GetCustomAttribute<CustomAttribute>();
            Map(typeof(T), property).Index(attribute.Index);
        }
    }
}
