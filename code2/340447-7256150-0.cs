    public string GetValue<T>(T value)
    {
        // Within here, value will still be a Nullable<X> for whatever type X
        // is appropriate. You can check this with Nullable.GetUnderlyingType
    }
  
