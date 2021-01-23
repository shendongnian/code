    /// <summary>
    /// Enables loading of xslt stylesheets from embedded resources.
    /// </summary>
    public class EmbeddedResourceResolver : XmlUrlResolver
    {
        public override object GetEntity(
            Uri absoluteUri,
            string role,
            Type ofObjectToReturn)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(absoluteUri.Segments.Last());
        }
    }
