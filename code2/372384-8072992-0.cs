    var cookies = new CookieContainer();
    // perform normal request;
    var webResponse; // be sure this gets assigned
    cookies.Add(webResponse.Cookies);
    // create another request
    var webRequest; // be sure this gets assigned
    webRequest.CookiesContainer = cookies;
    // perform next request. This time with cookies.
