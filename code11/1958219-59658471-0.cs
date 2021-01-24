C#
public class Tours
{
    [JsonPropertyName("types")]
    public List<UserType> Types { get; set; }
}
// Annotate the type to register the converter to use
[JsonConverter(typeof(CustomUserTypeConverter))]
public class UserType
{
    public string Key { get; set; }
    public Dictionary<string, int> Values { get; set; }
}
// This will use the low-level reader to build up the UserType
public class CustomUserTypeConverter : JsonConverter<UserType>
{
    // Extra structural validation was done for invalid/incomplete JSON
    // which might be too strict or incorrect and hence might require adjustments.
    public override UserType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new UserType();
        if (!reader.Read())
        {
            throw new JsonException("Incomplete JSON.");
        }
        if (reader.TokenType != JsonTokenType.EndArray)
        {
            result.Key = reader.GetString();
            ReadAndValidate(ref reader, JsonTokenType.StartArray);
            int depthSnapshot = reader.CurrentDepth;
            var values = new Dictionary<string, int>();
            do
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.StartArray && reader.TokenType != JsonTokenType.EndArray)
                {
                    throw new JsonException($"Invalid JSON payload. Expected Start or End Array. TokenType: {reader.TokenType}, Depth: {reader.CurrentDepth}.");
                }
                if (reader.CurrentDepth <= depthSnapshot)
                {
                    break;
                }
                reader.Read();
                if (reader.TokenType != JsonTokenType.EndArray)
                {
                    string key = reader.GetString();
                    reader.Read();
                    int value = reader.GetInt32();
                    values.Add(key, value);
                    ReadAndValidate(ref reader, JsonTokenType.EndArray);
                }
            } while (true);
            ReadAndValidate(ref reader, JsonTokenType.EndArray);
            result.Values = values;
        }
        return result;
    }
    private void ReadAndValidate(ref Utf8JsonReader reader, JsonTokenType expectedTokenType)
    {
        bool readNext = reader.Read();
        if (!readNext || reader.TokenType != expectedTokenType)
        {
            string message = readNext ?
                $"Invalid JSON payload. TokenType: {reader.TokenType}, Depth: {reader.CurrentDepth}, Expected: {expectedTokenType}" :
                $"Incomplete JSON. Expected: {expectedTokenType}";
            throw new JsonException(message);
        }
    }
    // Implement this method if you need to Serialize (i.e. write) the object
    // back to JSON
    public override void Write(Utf8JsonWriter writer, UserType value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
Here's how you would use the above converter to serialize the JSON string provided in the example, along with how to access the values.
C#
public static Tours ParseJson(string json)
{
    Tours tours = JsonSerializer.Deserialize<Tours>(json);
    return tours;
}
public static void AccessValues(Tours tours)
{
    foreach (UserType data in tours.Types)
    {
        string typeName = data.Key; // "tour_type"
        foreach (KeyValuePair<string, int> pairs in data.Values)
        {
            string key = pairs.Key; // "groups" or "individual
            int value = pairs.Value; // 1 or 2
        }
    }
}
For what it's worth, Visual Studio suggests the following C# class structure for the example JSON (which is similar to what @Jawad suggested):
C#
public class Rootobject
{
    public object[][] types { get; set; }
}
Hope that helps.
