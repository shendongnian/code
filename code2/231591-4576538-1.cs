    private static IEnumerable<Route> GetInlineRoutes()
    {
        var methods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a =>
                a.GetTypes()
                    .Where(t => t.IsClass && t.IsSubclassOf(typeof (Controller))))
            .SelectMany(c => c.GetMethods(BindingFlags.Public | BindingFlags.Instance));
        return from method in methods
            let urlAttributes = method.GetCustomAttributes(true).OfType<UrlAttribute>()
            from attr in urlAttributes
            select new Route(attr.Pattern, method, attr.Priority);
    }
