    public static string GetExceptionDetails(this Exception exception) {
        var properties = exception.GetType()
                                .GetProperties();
        var fields = properties.Select(
            property => String.Format("{0} = {1}", property.Name, property.GetValue(exception, null)));
        return String.Join("\n", fields);
    }
