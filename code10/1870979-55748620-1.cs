csharp
public static void Write<T>(string filepath, System.Collections.Generic.IEnumerable<T> records, string schema, string delimiter = "\t")
{
    var properties = typeof(T).GetProperties();
    var schemaList = schema.Split(';');
    if (properties.Count() != schemaList.Count())
    {
        throw new Exception("The given class does not have the same number of properties as the schema");
    }
    foreach (var name in schemaList)
    {
        if (!properties.Any(p => p.Name.ToUpper() == name.ToUpper()))
        {
            throw new Exception($"The given class is missing the property '{name}'");
        }
    }
    var config = new CsvHelper.Configuration.Configuration { Delimiter = delimiter };
    using (var writer = new System.IO.StreamWriter(filepath))
    using (var csv = new CsvHelper.CsvWriter(writer, config))
    {
        csv.WriteRecords(records);
    }
}
If you want to make sure the records at a minimum have the property names in the schema, but you don't care if they have extra properties and you don't want those extra properties written, you could use the `DefaultClassMap` to set that up.
csharp
public static void Write<T>(string filepath, System.Collections.Generic.IEnumerable<T> records, string schema, string delimiter = "\t")
{
    var properties = typeof(T).GetProperties();
    var classMap = new DefaultClassMap<T>();
    var schemaList = schema.Split(';');
    foreach (var name in schemaList)
    {
        if (!properties.Any(p => p.Name.ToUpper() == name.ToUpper()))
        {
            throw new Exception($"The given class is missing the property '{name}'");
        }
        var property = properties.FirstOrDefault(p => p.Name.ToUpper() == name.ToUpper());
        classMap.Map(typeof(T), property).Name(property.Name);
    }
    var config = new CsvHelper.Configuration.Configuration { Delimiter = delimiter };
    using (var writer = new System.IO.StreamWriter(filepath))
    using (var csv = new CsvHelper.CsvWriter(writer, config))
    {
        csv.Configuration.RegisterClassMap(classMap);
        csv.WriteRecords(records);
    }
}
