    static class Extensions
    {
        private static readonly Dictionary<Assembly, SourceLanguage> cache = new Dictionary<Assembly, SourceLanguage>();
        public static SourceLanguage GetSourceLanguage(this Type type) => type.Assembly.GetSourceLanguage();
        public static SourceLanguage GetSourceLanguage(this Assembly assembly)
        {
            if (cache.TryGetValue(assembly, out var sourceLanguage))
                return sourceLanguage;
            var assemblies = assembly.GetReferencedAssemblies().Select(a => a.Name);
            if (assemblies.Contains("Microsoft.VisualBasic"))
                sourceLanguage = SourceLanguage.VB;
            else if (assemblies.Contains("FSharp.Core"))
                sourceLanguage = SourceLanguage.FSharp;
            else
                sourceLanguage = SourceLanguage.Unknown;
            cache[assembly] = sourceLanguage;
            return sourceLanguage;
        }
    }
	
