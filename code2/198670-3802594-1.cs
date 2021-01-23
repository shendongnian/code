    public static String GetPublicPropertiesAsString( this Object @this )
    {
      return GetAsString<PropertyInfo>(@this, x => x.GetValue(@this, null));
    }
    
    public static String GetPublicFieldsAsString( this Object @this )
    {
      return GetAsString<FieldInfo>(@this, x => x.GetValue(@this));
    }
