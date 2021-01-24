    public static class Extensions {
        public static string GetString (this IHtmlHelper helper, string key) {
            IServiceProvider services = helper.ViewContext.HttpContext.RequestServices;
            IViewLocalizer localizer = services.GetRequiredService<IViewLocalizer>();
            return localizer[key]
        }
    }
