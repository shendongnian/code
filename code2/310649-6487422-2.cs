    public HttpCookie AddHttpCookie(String key, String value, int timeOut)
    {
        HttpCookie httpCookie = new HttpCookie(key, value);
        httpCookie.Expires = DateTime.Now.AddMinutes(timeOut);
        Response.Cookies.Add(httpCookie);
        return httpCookie;
    }
