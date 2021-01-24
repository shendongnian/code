    using (JsonReader reader = new JsonTextReader(sr))
    {
        while (!sr.EndOfStream)
        {
            o = serializer.Deserialize<List<MyObject>>(reader);
        }
    }
