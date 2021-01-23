    public static string Pluralize(this string value, int count)
    {
        if (count <= 1)
        {
            return value;
        }
        return PluralizationService
            .CreateService(new CultureInfo("en-US"))
            .Pluralize(value);
    }
