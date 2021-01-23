    public static int? GetInt32OrNull(this CookieCollection cookies, string name)
    {
        if (cookies == null)
        {
            throw ArgumentNullException("cookies");
        }
        if (name == null)
        {
            throw ArgumentNullException("name");
        }
        string cookieValue = cookies.Get(name).Value;
        if (cookieValue == null)
        {
            return null;
        }
        int size;
        if (int.TryParse(cookieValue, CultureInfo.InvariantCulture, out size))
        {
            return size;
        }
        // Couldn't parse...
        return null;
    }
