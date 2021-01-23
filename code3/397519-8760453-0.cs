    response = service1.Authenticate();
    CookieCollection allCookies= service1.CookieContainer.GetCookies(uri);
    foreach (Cookie c in allCookies)
    {
      service2.CookieContainer.SetCookies(_uri,c.Name + "=" +  c.Value);
    }
    service2.CallMyMethod();
