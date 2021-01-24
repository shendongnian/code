    public static string PrintMe(object obj, string propertyName)
    {
        string message = "";
        message += obj.GetType().GetProperty(propertyName)?.GetValue(obj);
        return message;
    }
