    public static string GetValue(this Session session, string key)
    {
       // TODO: Insert appropriate error checking here.
       return (session[key] ?? String.Empty).ToString();
    }
