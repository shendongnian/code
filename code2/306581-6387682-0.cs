    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
       if (colour== null)
       {
           colour= "This value was set after deserialization.";
       }
    }
