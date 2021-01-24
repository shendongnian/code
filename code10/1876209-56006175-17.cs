    static class Extensions
    {
        private static readonly Dictionary<Assembly, SourceLanguage> cache = new Dictionary<Assembly, SourceLanguage>();
        public static SourceLanguage GetSourceLanguage(this Type type) => type.Assembly.GetSourceLanguage();
        public static SourceLanguage GetSourceLanguage(this Assembly assembly)
        {
            if (cache.TryGetValue(assembly, out var sourceLanguage))
                return sourceLanguage;
            var name = assembly.GetName().Name;
            var resources = assembly.GetManifestResourceNames();
            if (resources.Contains($"{name}.Resources.resources"))
                sourceLanguage = SourceLanguage.VB;
            else if (resources.Contains($"FSharpSignatureData.{name}"))
                sourceLanguage = SourceLanguage.FSharp;
            else
                sourceLanguage = SourceLanguage.Unknown;
            cache[assembly] = sourceLanguage;
            return sourceLanguage;
        }
    }
