    public class CustomResourceManager : ResourceManager
    {
        public CustomResourceManager(Type resourceSource)
            :base(resourceSource)
        {
        }
        public CustomResourceManager(string baseName, Assembly assembly)
            : base(baseName, assembly)
        {
        }
        public CustomResourceManager(string baseName, Assembly assembly, Type usingResourceSet)
            : base(baseName, assembly, usingResourceSet)
        {
        }
        public override string GetString(string name)
        {
            // your business logic
        }
        public override string GetString(string name, CultureInfo culture)
        {
            // your business logic
        }
    }
