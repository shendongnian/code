    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var valueDto = (DateTimeOffset)(DateTime)value;
        var milliseconds = (valueDto).ToUnixTimeMilliseconds();
        writer.WriteValue(milliseconds);
    }
