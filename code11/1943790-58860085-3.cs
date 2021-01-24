    if (value is List<double> myList)
    {
        writer.WriteStartArray();
        foreach (var element in myList)
        {
            writer.WriteValue(element);
        }
        writer.WriteEndArray();
    }
