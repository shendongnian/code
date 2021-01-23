    public object SerializedValue
    {
      get
      {
        if (this._ChangedSinceLastSerialized)
           return CalculateSerializedData();
        else
           return _cachedData;
       }
    }
