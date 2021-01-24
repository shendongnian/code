    private static double ConvertNullableDoubleToDouble(double? input, double? defaultIfNull = null)
    {
      if (input != null && input.HasValue)
        return input.Value;
      else if (defaultIfNull != null && defaultIfNull.HasValue)
        return defaultIfNull.Value;
      else
        throw new Exception(string.Format($"Unable to parse input {input}"));
    }
