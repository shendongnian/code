    // Inside your custom JsonConverter
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var pitem = value as PItem;
        writer.WriteStartObject();
        writer.WritePropertyName("name");
        serializer.Serialize(writer, pitem.name);
        writer.WritePropertyName("child");
        // This respects any additional JsonConverters added to the serializer
        serializer.Serialize(writer, pitem.child);
        writer.WriteEndObject();
    }
