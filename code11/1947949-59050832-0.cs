    services.AddDataProtection()
        .PersistKeysToFileSystem("{PATH TO COMMON KEY RING FOLDER}")
        .SetApplicationName("SharedCookieApp");
    
    services.ConfigureApplicationCookie(options => {
        options.Cookie.Name = ".AspNet.SharedCookie";
        options.Cookie.Path = "/";
    });
