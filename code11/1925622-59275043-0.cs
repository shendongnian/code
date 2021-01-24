    public class Localizer
    {
        private readonly IStringLocalizer localizer;
        public Localizer(IStringLocalizerFactory fact)
        {
            var type = typeof(SharedResource);
            var assembly = new AssemblyName(type.GetTypeInfo().Assembly.FullName).Name;
            localizer = fact.Create(nameof(SharedResource), assembly);
        }
        public LocalizedString this[string key] => localizer[key];
        public LocalizedString this[string key, params object[] arguments] => localizer[key, arguments];
    }
And then inject that into your controllers and views. Based on this guy's blog post: https://medium.com/@flouss/asp-net-core-localization-one-resx-to-rule-them-all-de5c07692fa4
