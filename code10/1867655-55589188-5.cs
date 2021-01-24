    public override void WriteJson(JsonWriter writer, Period period, JsonSerializer serializer)
    {
        var token = JToken.FromObject(new {Start = period.Start, End = period.End});
        token.WriteTo(writer);
    }
