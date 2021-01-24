    var dict = new SerializableDictionary<int, string>();
    dict.SetValue(1, default);
    dict.SetValue(2, "");
    dict.SetValue(3, "Andromeda");
    var binaryFormatter = new BinaryFormatter();
    var stream = new MemoryStream();
    binaryFormatter.Serialize(stream, dict);
    stream.Position = 0;
    dict = (SerializableDictionary<int, string>)binaryFormatter.Deserialize(stream);
    foreach (var key in dict.GetKeys())
    {
        var value = dict.getValueFromKey(key);
        Console.Write($"Key: {key}, Value: ");
        if (value == null)
        {
            Console.WriteLine("null");
        }
        else if (value == String.Empty)
        {
            Console.WriteLine("String.Empty");
        }
        else
        {
            Console.WriteLine($"\"{value}\"");
        }
    }
