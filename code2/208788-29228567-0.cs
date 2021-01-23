    [OnSerializing]
    public void OnSerializing(StreamingContext context)
    {
      var properties = this.GetType().GetProperties();
      foreach (PropertyInfo property in properties)
      {
        if (property.PropertyType == typeof(DateTime) && property.GetValue(this).Equals(DateTime.MinValue))
        {
          property.SetValue(this, DateTime.MinValue.ToUniversalTime());
        }
      }
    }
