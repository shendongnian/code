    public static string GetFilename(this XmlSiteMapProvider provider)
    {
        Type type = provider.GetType();
        FieldInfo filenameField = type.GetField("_filename", BindingFlags.Instance | BindingFlags.NonPublic);
        return (string)filenameField.GetValue(provider);
    }
