    public class MvcApplication : HttpApplication 
    {
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new PageViewAttribute());
            }
    }
