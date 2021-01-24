    public static string SerializeWithCustomFormatting(object obj, int n)
    {
        using (TextWriter sw = new StringWriter())
        using (JsonWriter writer = new CustomJsonWriter(sw, n))
        {
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(writer, obj);
            return sw.ToString();
        }
    }
