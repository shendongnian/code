    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var milliseconds = ((DateTimeOffset)(DateTime)value).ToUnixTimeMilliseconds();
        writer.WriteValue(milliseconds);
    }
