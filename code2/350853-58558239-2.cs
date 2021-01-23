    public string GetValueFromCookies(HttpCookieCollection cookies)
    {
        if (cookies == null)
        {
            throw new ArgumentNullException(nameof(cookies));
        }
        // check the existence of key in the list first
        if (Array.IndexOf(cookies.AllKeys, key) < 0)
        {
            return null;
        }
        // because the following line adds a cookie with empty value if it's not there
        return cookies[key].Value;
    }
