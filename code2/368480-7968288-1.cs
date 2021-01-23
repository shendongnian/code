    private static string SerializeWithoutQuote(object value)
    {
        var serializer = JsonSerializer.Create(null);
        using (var stringWriter = new StringWriter())
        using (var jsonWriter = new JsonTextWriter(stringWriter))
        {
            jsonWriter.QuoteName = false;
            serializer.Serialize(jsonWriter, value);
            return stringWriter.ToString();
        }
    }
