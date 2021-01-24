    double ConvertNullableDoubleToDouble<T>(double? input, double? defaultIfNull = null)
    {
        if (input != null && input.HasValue)
            return input.Value;
        else if (defaultIfNull != null && defaultIsNull.HasValue)
            return defaultIfNull;
        else
            throw new Exception(string.Format("Unable to parse input {}", input));
    }
