    public static string GetValue(this HttpSessionState session, string key)
    {
       // TODO: Insert appropriate error checking here.
       return (session[key] ?? String.Empty).ToString();
    }
