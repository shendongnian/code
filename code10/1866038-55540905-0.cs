csharp
var config = new Configuration
{
    HasHeaderRecord = false,
    AllowComments = true
};
using (var stream = new StreamReader(filepath))
using (var reader = new CsvReader(stream, config))
{
    while (reader.Read())
    {
        BsonDocument doc = new BsonDocument
        {
            { "A", reader.GetField(0)},
            { "B", reader.GetField(1)},
            { "C", reader.GetField(2).ToLower()},
            { "D", reader.GetField(3)},
            { "E", Convert.ToBoolean(reader.GetField(4))},
            { "F", Convert.ToBoolean(reader.GetField(5))}
        };
    }
}
