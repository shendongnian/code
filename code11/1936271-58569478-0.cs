    public class ProxyBase
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return Message;
        }
    }
    public static T OverrideToString<T>(this T ob, message) where T : class
    {
        var g = new ProxyGenerator();
        var o = new ProxyGenerationOptions();
        o.BaseTypeForInterfaceProxy = typeof(ProxyBase);
        var proxied = g.CreateInterfaceProxyWithTarget(ob, o);
        var baseProxy = proxied as ProxyBase;
        baseProxy.Name = message;
        return proxied;
    }
