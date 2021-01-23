    public static class XmlPreloadedResolverExtensions
    {
        private const string Xhtml11DtdPublicId = "-//W3C//DTD XHTML 1.1//EN";
        private const string Xhtml11DtdSystemId = "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd";
        public static void AddXhtml11(this XmlPreloadedResolver resolver, bool @override = false)
        {
            Add(resolver, new Uri(Xhtml11DtdPublicId, UriKind.RelativeOrAbsolute), ManifestResources.xhtml11_flat_dtd, @override);
            Add(resolver, new Uri(Xhtml11DtdSystemId, UriKind.RelativeOrAbsolute), ManifestResources.xhtml11_flat_dtd, @override);
        }
        public static bool Add(this XmlPreloadedResolver resolver, Uri uri, Stream value, bool @override)
        {
            if (@override || !resolver.PreloadedUris.Contains(uri))
            {
                resolver.Add(uri, value);
                return true;
            }
            return false;
        }
    }
