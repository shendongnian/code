    public class LocalizedResourceExtension : MarkupExtension
    {
        [ConstructorArgument("resourceKey")]
        public string ResourceKey { get; set; }
    
        public CultureInfo Culture { get; set; }
    
        public LocalizedResourceExtension()
        {
        }
    
        public LocalizedResourceExtension(string resourceKey)
        {
            this.ResourceKey = resourceKey;
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(ResourceKey))
                throw new InvalidOperationException("ResourceKey must be set");
            return Properties.Resources.ResourceManager.GetValue(
                ResourceKey, 
                Culture ?? CultureInfo.CurrentUICulture);
        }
    }
