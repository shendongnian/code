    public static T GetVal<T>(this HttpSessionStateBase Session, string key, Func<IList<object>,T> getValues, IList<object> args)
    {
        if (Session[key] == null)
            Session[key] = getValues(args);
        return (T)Session[key];
    }
