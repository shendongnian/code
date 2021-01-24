    static class Extensions
    {
        private static readonly Dictionary<Assembly, SourceLanguage> cache = new Dictionary<Assembly, SourceLanguage>();
        public static SourceLanguage GetSourceLanguage(this Type type) => type.Assembly.GetSourceLanguage();
        public static SourceLanguage GetSourceLanguage(this Assembly assembly)
        {
            if (cache.TryGetValue(assembly, out var sourceLanguage))
                return sourceLanguage;
            sourceLanguage = assembly.GetReferencedAssemblies().Select(a => a.Name).Contains("Microsoft.VisualBasic") ?
                SourceLanguage.VB :
                SourceLanguage.Unknown;
            cache[assembly] = sourceLanguage;
            return sourceLanguage;
        }
    }
	
