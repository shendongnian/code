    using(var file = File.Create(path))
    {
        Serializer.Serialize(file, obj);
    }
    ...
    using(var file = File.OpenRead(path))
    {
        var obj = Serializer.Deserialize<YourType>(file);
    }
