     var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "ASP.NET_SessionId");
     if (sessionCookie != null)
     {
        _cookieJar.Add(new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
     }
