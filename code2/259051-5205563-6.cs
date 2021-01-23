    using System.Web.SessionState;
    public static T GetValue<T>(this HttpSessionState session, string key, Func<object, T> valueSelector)
    {
        return valueSelector(session[key]);
    }
    public static string GetStringValue(this HttpSessionState session, string key)
    {
        return session.GetValue(key, x => (x ?? String.Empty).ToString());
    }
