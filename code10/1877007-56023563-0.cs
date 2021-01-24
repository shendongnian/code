    public class MyConfigureOptions : IConfigureOptions<MvcOptions>
    {
        public void Configure(MvcOptions options)
        {
            options.ModelBinderProviders.Insert(0,new MyModelBinderProvider());
        }
    }
