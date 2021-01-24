    public enum SourceLanguage
    {
        Unknown, // probably C# for it's the only language without any particular symptom
        VB,
		FSharp,
        Cpp
    }
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
            var assemblies = assembly.GetReferencedAssemblies().Select(a => a.Name);
            var types = assembly.DefinedTypes;
            if (assemblies.Contains("Microsoft.VisualBasic") &&
                resources.Contains($"{name}.Resources.resources"))
                sourceLanguage = SourceLanguage.VB;
            else if (assemblies.Contains("FSharp.Core") &&
                     resources.Contains($"FSharpSignatureData.{name}") &&
                     resources.Contains($"FSharpOptimizationData.{name}"))
                sourceLanguage = SourceLanguage.FSharp;
            else if (types.Any(t => t.FullName.Contains("<CppImplementationDetails>.")))
                sourceLanguage = SourceLanguage.Cpp;
            else
                sourceLanguage = SourceLanguage.Unknown;
            cache[assembly] = sourceLanguage;
            return sourceLanguage;
        }
    }
	
