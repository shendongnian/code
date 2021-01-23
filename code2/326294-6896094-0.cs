    private int intValue;                // Legacy field
    private SomeStruct structValue;      // New field
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      if (intValue != 0)
      {
          // Old format, initialize struct with int value.
          structValue = new SomeStruct(intValue);
      }
    }
