    public void WriteData<T>(IEnumerable<T> objects) where T : class
    {
      foreach (var obj in objects)
      {
        WriteObjectData(obj);
      }
    }
    
    private void WriteObjectData<T>(T obj) where T : class
    {
        foreach (var propertyInfo in typeof(T).GetProperties())
        {
            // Use propertyInfo.GetValue to get the value from obj. 
        }
    }
