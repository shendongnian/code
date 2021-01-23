    CookieCollection cookiesResponse = new CookieCollection();
    if (response != null)
    {
        foreach (string cookie in response.Headers["Set-Cookie"].Split(';'))
        {
            string name = cookie.Split('=')[0];
            string value = cookie.Substring(name.Length + 1);
            cookiesResponse.Add(new Cookie(name.Trim(), value.Trim(), path, domain));
        }
    }
