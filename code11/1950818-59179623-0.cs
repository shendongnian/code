csharp
public static List<T> ConvertTo<T, TMap>(string file, IEnumerable<CsvMapping> headers) where T : class
                    where TMap : ClassMap<T>
{
    using (var reader = new StreamReader(file, Encoding.GetEncoding("iso-8859-1")))
    using (var csvReader = new CsvReader(reader))
    {
        var good = new List<T>();
        // Set up CSV Helper
        csvReader.Configuration.Delimiter = ";";
        csvReader.Configuration.IgnoreQuotes = true;
        csvReader.Configuration.HasHeaderRecord = true;
        csvReader.Configuration.HeaderValidated = null;
        csvReader.Configuration.MissingFieldFound = null;
        csvReader.Configuration.TrimOptions = TrimOptions.Trim;
        var classMap = csvReader.Configuration.RegisterClassMap<TMap>();
        classMap.Map(headers);
        good = csvReader.GetRecords<T>().ToList();
        return good.ToList();
    }
}
public class CsvMapping 
{
    public string CsvHeaderName { get; set; }
    public string PropertyName { get; set; }
    public bool Optional { get; set; }
}
public static class CsvHelperExtensions
{
    public static void Map<T>(this ClassMap<T> classMap, IEnumerable<CsvMapping> csvMappings)
    {
        foreach (var mapping in csvMappings)
        {
            var property = typeof(T).GetProperty(mapping.PropertyName);
            if (property == null)
            {
                throw new ArgumentException($"Class {typeof(T).Name} does not have a property named {mapping.PropertyName}");
            }
            if (mapping.CsvHeaderName != null)
            {
                classMap.Map(typeof(T), property).Name(mapping.CsvHeaderName);
            }
            //// Pull request to CsvHelper to fix the Optional() method. 3/14/2019
            //if (mapping.Optional)
            //{
            //    classMap.Map(typeof(T), property).Optional();
            //}
        }
    }
}
public class ResponseMap : ClassMap<ResponseNgi>
{
    public ResponseMap()
    {
        Map(m => m.Street);
        Map(m => m.HouseNumber);
        Map(m => m.PostalCode);
        Map(m => m.MunicipalitySection);
        Map(m => m.Municipality);
        Map(m => m.StreetCode);
        Map(m => m.Xlambert).TypeConverter<CustomDoubleConverter>().Optional();
        Map(m => m.YLambert).TypeConverter<CustomDoubleConverter>().Optional();
        Map(m => m.ZLambert).TypeConverter<CustomDoubleConverter>().Optional();
        Map(m => m.Nrn).Optional();
        Map(m => m.Source).Optional();
        Map(m => m.Method).Optional();
        Map(m => m.GeoadresId);
    }
}
