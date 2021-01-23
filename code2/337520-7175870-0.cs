    private static void GetLocalizedDisplayNameForClass<T>(ModelMetadata meta, string propertyName)
    {
        ResourceManager rm = new ResourceManager(typeof(T));
        CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
        string resource = string.Format("{0}_{1}", meta.ContainerType.Name, meta.PropertyName).ToLower();
        meta.DisplayName = rm.GetString(resource, culture);
    }
