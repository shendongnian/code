    public static T RequestGet<T>(string key)
    {
        if (Request[key] == null)
        {
            return default(T);
        }
        else
        {
            return (T)Convert.ChangeType(Request[key], typeof(T));
            // return (T)Request[key];
        }
    }
