    public static async Task SomeExtensionAsync(this IWebHost webHost)
    {
        var config = webHost.Services.GetService<IConfiguration>();
        // Your initialisation code here with awaits.
        // ...
    }
