    public static object ChangeType
        (object value, Type conversionType, IFormatProvider provider)
    {
        int country;
        if (conversionType == typeof(Country)
            && int.TryParse(value.ToString(), out country))
        {
            switch (country)
            {
                case 1:
                case 2:
                    return Country.US;
                case 3:
                case 4:
                    return Country.Canada;
            }
        }
        return System.Convert.ChangeType(value, conversionType, provider);
    }
