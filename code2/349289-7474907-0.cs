    public string StringToProperty(string fieldName)
    {
      Type myType = this.GetType();
      FieldInfo field = myType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
      return Convert.ToString(field.GetValue(this)); 
    }
