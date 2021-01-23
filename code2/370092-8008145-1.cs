    using(var writer = File.CreateText(path))
    {
        Serialize(writer);
    }
    ...
    void Serialize(TextWriter writer)
    {
        ...
    }
