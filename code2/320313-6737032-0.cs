    /// <summary>
    /// This wrapper around Convert.ChangeType was done to handle nullable types.
    /// See original authors work here: http://aspalliance.com/852
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="conversionType">The type to convert to.</param>
    /// <returns></returns>
    public static object ChangeType(object value, Type conversionType)
    {
      if (conversionType == null)
      {
        throw new ArgumentNullException("conversionType");
      }
      if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
      {
        if (value == null)
        {
          return null;
        }
        NullableConverter nullableConverter = new NullableConverter(conversionType);
        conversionType = nullableConverter.UnderlyingType;
      }
      return Convert.ChangeType(value, conversionType);
    }
