csharp
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class TriangleJsonConverter : JsonConverter<Triangle>
{
    // Called when Triangle is written
    public override void WriteJson(JsonWriter writer, Triangle value, JsonSerializer serializer)
    {
        // Uses JsonSerializer to write the int[] to the JsonWriter
        serializer.Serialize(writer, value.Indices);
    }
    
    // Called when Triangle is read
    public override Triangle ReadJson(JsonReader reader, Type objectType, Triangle existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        // Reads a json array (JArray) from the JsonReader
        var array = JArray.Load(reader);
        // Creates a new Triangle.
        return new Triangle
        {
            // converts the json array to an int[]
            Indices = array.ToObject<int[]>()
        };
    }
}
To tell JSON.NET to use the `TriangleJsonConverter` you need to apply `JaonArray` to the `Triangles` field instead of `JsonProperty`.
csharp
public class Mesh
{
    [JsonArray(ItemConverterType = typeof(TriangleJsonConverter))]
    public Triangle[] Triangles { get; set; }
}
