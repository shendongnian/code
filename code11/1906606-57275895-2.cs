    public static void SerializeToFile(IEnumerable items, string fileName, bool append = true)
    {
        using (StreamWriter sw = new StreamWriter(fileName, append))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            var ser = new JsonSerializer();
            foreach (var item in items)
            {
                ser.Serialize(writer, item);
                writer.WriteWhitespace(Environment.NewLine);
            }
        }
    }
