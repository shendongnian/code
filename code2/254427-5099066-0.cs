    [OnDeserializing]
    public void OnDeserializing(StreamingContext context)
    {
        IsNotifying = false;
    }
    [OnDeserialized]
    public void OnDeserialized(StreamingContext context)
    {
        IsNotifying = true;
    }
