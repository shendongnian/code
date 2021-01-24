    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder SetCustomControllerRoute(this IMvcBuilder mvcBuilder, string newEndpoint)
        {
            return mvcBuilder.AddMvcOptions(o =>
            {
                o.Conventions.Add(new CustomControllerConvention(newEndpoint));
            });
        }
    }
