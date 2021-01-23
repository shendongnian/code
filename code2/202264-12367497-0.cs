    public static T TryParse<T>(string value, T defaultValue) where T: struct
        {
            if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }
                T result;
                if (Enum.TryParse<T>(value, out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;  // you may want to throw exception here
                }
            }
        }
        ConverterMode mode = EnumUtils<ConverterMode>.TryParse(stringValue, ConverterMode.DefaultMode);
