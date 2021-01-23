    public HttpCookie CreateCookie(string name, string value, string path)
    {
        var cookie = new HttpCookie(name, value);
        cookie.Path = path;
        return cookie;
    }
