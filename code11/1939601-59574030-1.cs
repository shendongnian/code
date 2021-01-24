C#
public static string SimpleObjectMerge(string originalJson, string newContent)
{
    var outputBuffer = new ArrayBufferWriter<byte>();
    using (JsonDocument jDoc1 = JsonDocument.Parse(originalJson))
    using (JsonDocument jDoc2 = JsonDocument.Parse(newContent))
    using (var jsonWriter = new Utf8JsonWriter(outputBuffer, new JsonWriterOptions { Indented = true }))
    {
        JsonElement root1 = jDoc1.RootElement;
        JsonElement root2 = jDoc2.RootElement;
        // Assuming both JSON strings are single JSON objects (i.e. {...})
        Debug.Assert(root1.ValueKind == JsonValueKind.Object);
        Debug.Assert(root2.ValueKind == JsonValueKind.Object);
        jsonWriter.WriteStartObject();
        // Write all the properties of the first document that don't conflict with the second
        foreach (JsonProperty property in root1.EnumerateObject())
        {
            if (!root2.TryGetProperty(property.Name, out _))
            {
                property.WriteTo(jsonWriter);
            }
        }
        // Write all the properties of the second document (including those that are duplicates which were skipped earlier)
        // The property values of the second document completely override the values of the first
        foreach (JsonProperty property in root2.EnumerateObject())
        {
            property.WriteTo(jsonWriter);
        }
        jsonWriter.WriteEndObject();
    }
    return Encoding.UTF8.GetString(outputBuffer.WrittenSpan);
}
`Newtonsoft.Json` has different `null` handling when doing a merge where `null` doesn't override the value of the non-null property (when there are duplicates). I am not sure if you want that behavior or not. If that's needed, you would need to modify the above method to handle the `null` cases. Here are the modifications:
C#
public static string SimpleObjectMergeWithNullHandling(string originalJson, string newContent)
{
    var outputBuffer = new ArrayBufferWriter<byte>();
    using (JsonDocument jDoc1 = JsonDocument.Parse(originalJson))
    using (JsonDocument jDoc2 = JsonDocument.Parse(newContent))
    using (var jsonWriter = new Utf8JsonWriter(outputBuffer, new JsonWriterOptions { Indented = true }))
    {
        JsonElement root1 = jDoc1.RootElement;
        JsonElement root2 = jDoc2.RootElement;
        // Assuming both JSON strings are single JSON objects (i.e. {...})
        Debug.Assert(root1.ValueKind == JsonValueKind.Object);
        Debug.Assert(root2.ValueKind == JsonValueKind.Object);
        jsonWriter.WriteStartObject();
        // Write all the properties of the first document that don't conflict with the second
        // Or if the second is overriding it with null, favor the property in the first.
        foreach (JsonProperty property in root1.EnumerateObject())
        {
            if (!root2.TryGetProperty(property.Name, out JsonElement newValue) || newValue.ValueKind == JsonValueKind.Null)
            {
                property.WriteTo(jsonWriter);
            }
        }
        // Write all the properties of the second document (including those that are duplicates which were skipped earlier)
        // The property values of the second document completely override the values of the first, unless they are null in the second.
        foreach (JsonProperty property in root2.EnumerateObject())
        {
            // Don't write null values, unless they are unique to the second document
            if (property.Value.ValueKind != JsonValueKind.Null || !root1.TryGetProperty(property.Name, out _))
            {
                property.WriteTo(jsonWriter);
            }
        }
        jsonWriter.WriteEndObject();
    }
    return Encoding.UTF8.GetString(outputBuffer.WrittenSpan);
}
**If your JSON objects can potentially contain nested JSON values including other objects and arrays**, you would want to extend the logic to handle that too. Something like this should work:
C#
public static string Merge(string originalJson, string newContent)
{
    var outputBuffer = new ArrayBufferWriter<byte>();
    using (JsonDocument jDoc1 = JsonDocument.Parse(originalJson))
    using (JsonDocument jDoc2 = JsonDocument.Parse(newContent))
    using (var jsonWriter = new Utf8JsonWriter(outputBuffer, new JsonWriterOptions { Indented = true }))
    {
        JsonElement root1 = jDoc1.RootElement;
        JsonElement root2 = jDoc2.RootElement;
        if (root1.ValueKind != JsonValueKind.Array && root1.ValueKind != JsonValueKind.Object)
        {
            throw new InvalidOperationException($"The original JSON document to merge new content into must be a container type. Instead it is {root1.ValueKind}.");
        }
        if (root1.ValueKind != root2.ValueKind)
        {
            return originalJson;
        }
        if (root1.ValueKind == JsonValueKind.Array)
        {
            MergeArrays(jsonWriter, root1, root2);
        }
        else
        {
            MergeObjects(jsonWriter, root1, root2);
        }
    }
    return Encoding.UTF8.GetString(outputBuffer.WrittenSpan);
}
private static void MergeObjects(Utf8JsonWriter jsonWriter, JsonElement root1, JsonElement root2)
{
    Debug.Assert(root1.ValueKind == JsonValueKind.Object);
    Debug.Assert(root2.ValueKind == JsonValueKind.Object);
    jsonWriter.WriteStartObject();
    // Write all the properties of the first document.
    // If a property exists in both documents, either:
    // * Merge them, if the value kinds match (e.g. both are objects or arrays),
    // * Completely override the value of the first with the one from the second, if the value kind mismatches (e.g. one is object, while the other is an array or string),
    // * Or favor the value of the first (regardless of what it may be), if the second one is null (i.e. don't override the first).
    foreach (JsonProperty property in root1.EnumerateObject())
    {
        string propertyName = property.Name;
        JsonValueKind newValueKind;
        if (root2.TryGetProperty(propertyName, out JsonElement newValue) && (newValueKind = newValue.ValueKind) != JsonValueKind.Null)
        {
            jsonWriter.WritePropertyName(propertyName);
            JsonElement originalValue = property.Value;
            JsonValueKind originalValueKind = originalValue.ValueKind;
            if (newValueKind == JsonValueKind.Object && originalValueKind == JsonValueKind.Object)
            {
                MergeObjects(jsonWriter, originalValue, newValue); // Recursive call
            }
            else if (newValueKind == JsonValueKind.Array && originalValueKind == JsonValueKind.Array)
            {
                MergeArrays(jsonWriter, originalValue, newValue);
            }
            else
            {
                newValue.WriteTo(jsonWriter);
            }
        }
        else
        {
            property.WriteTo(jsonWriter);
        }
    }
    // Write all the properties of the second document that are unique to it.
    foreach (JsonProperty property in root2.EnumerateObject())
    {
        if (!root1.TryGetProperty(property.Name, out _))
        {
            property.WriteTo(jsonWriter);
        }
    }
    jsonWriter.WriteEndObject();
}
private static void MergeArrays(Utf8JsonWriter jsonWriter, JsonElement root1, JsonElement root2)
{
    Debug.Assert(root1.ValueKind == JsonValueKind.Array);
    Debug.Assert(root2.ValueKind == JsonValueKind.Array);
    jsonWriter.WriteStartArray();
    // Write all the elements from both JSON arrays
    foreach (JsonElement element in root1.EnumerateArray())
    {
        element.WriteTo(jsonWriter);
    }
    foreach (JsonElement element in root2.EnumerateArray())
    {
        element.WriteTo(jsonWriter);
    }
    jsonWriter.WriteEndArray();
}
**Note:** If performance is critical for your scenario, this method (even with writing indented) out-performs the Newtonsoft.Json's `Merge` method both in terms of runtime and allocations. That said, the implementation could be made faster depending on need (for instance, don't write indented, cache the `outputBuffer`, don't accept/return strings, etc.).
 ini
BenchmarkDotNet=v0.12.0, OS=Windows 10.0.19041
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-alpha1-015914
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.19.56303, CoreFX 5.0.19.56306), X64 RyuJIT
  Job-LACFYV : .NET Core 5.0.0 (CoreCLR 5.0.19.56303, CoreFX 5.0.19.56306), X64 RyuJIT
PowerPlanMode=00000000-0000-0000-0000-000000000000  
md
|          Method |     Mean |    Error |   StdDev |   Median |      Min |      Max | Ratio |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|---------------- |---------:|---------:|---------:|---------:|---------:|---------:|------:|-------:|-------:|------:|----------:|
| MergeNewtonsoft | 29.01 us | 0.570 us | 0.656 us | 28.84 us | 28.13 us | 30.19 us |  1.00 | 7.0801 | 0.0610 |     - |  28.98 KB |
|       Merge_New | 16.41 us | 0.293 us | 0.274 us | 16.41 us | 16.02 us | 17.00 us |  0.57 | 1.7090 |      - |     - |   6.99 KB |
