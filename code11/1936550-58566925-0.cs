public override void Write(Utf8JsonWriter writer, Book value, JsonSerializerOptions options)
{
    writer.WriteStartObject();
    using (JsonDocument document = JsonDocument.Parse(JsonSerializer.Serialize(value)))
    {
        foreach (var property in document.RootElement.EnumerateObject())
        {
            if (property.Name != "Author")
                property.WriteTo(writer);
        }
    }
    writer.WriteEndObject();
}
