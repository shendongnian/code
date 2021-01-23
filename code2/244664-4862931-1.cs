    public static class NewsRegistration()
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            // Register your specific types here.
            builder.RegisterType<NewsService>().As<INewsService>();
        }
    }
