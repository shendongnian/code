    public static IFlurlClient AllowAutoRedirect(this IFlurlClient fc, bool allowAutoRedirect)
    {
        var fac = fc.Settings.HttpClientFactory as CustomHttpClientFactory ??
            new CustomHttpClientFactory();
        fac.AutoRedirect = allowAutoRedirect;
        fc.Settings.HttpClientFactory = fac;
        return fc;
    }
    public static IFlurlClient Proxy(this IFlurlClient fc, Proxy proxy)
    {
        var fac = fc.Settings.HttpClientFactory as CustomHttpClientFactory ??
            new CustomHttpClientFactory();
        fac.Proxy = proxy;
        fc.Settings.HttpClientFactory = fac;
        return fc;
    }
