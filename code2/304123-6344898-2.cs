    [OnDeserialized]
    public void OnDeserializedMethod(StreamingContext context)
    {
      IsDeserializing = false;
      ChangeTracker.ChangeTrackingEnabled = true;
    }
