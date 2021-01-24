    services.AddDataProtection()
             .PersistKeysToFileSystem(new DirectoryInfo(@"d:\Keys"))
             .SetApplicationName("SharedCookieApp");
    services.ConfigureApplicationCookie(options => {
              options.Cookie.Name = ".AspNet.SharedCookie";
            });
