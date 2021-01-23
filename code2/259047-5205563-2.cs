    public static T GetValue<T>(this Session session, string key, Func<object, T> valueSelector)
    {
        return valueSelector(session[key]);
    }
    public static string GetStringValue(this Session session, string key)
    {
        return session.GetValue(x => (x ?? String.Empty).ToString());
    }
