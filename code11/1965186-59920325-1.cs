    public class DynamicRepositoriesBuildInfo
    {
     public IReadOnlyCollection<Assembly> ReferencesAssemblies { get; }
        public IReadOnlyCollection<FieldInfo> PluginCommandFieldInfos { get; }
        
        public DynamicRepositoriesBuildInfo(
            IReadOnlyCollection<Assembly> referencesAssemblies,
            IReadOnlyCollection<FieldInfo> pluginCommandFieldInfos)
        {
            this.ReferencesAssemblies = referencesAssemblies;
            this.PluginCommandFieldInfos = pluginCommandFieldInfos;
        }
    }
    private static DynamicRepositoriesBuildInfo GetDynamicRepositoriesBuildInfo()
        {
        var pluginCommandProperties = (from a in AppDomain.CurrentDomain.GetAssemblies()
                                       let entryAttr = a.GetCustomAttribute<PluginEntryAttribute>()
                                       where entryAttr != null
                                       from t in a.DefinedTypes
                                       where t == entryAttr.PluginType
                                       from p in t.GetFields(BindingFlags.Public | BindingFlags.Instance)
                                       where p.FieldType.GetGenericTypeDefinition() == typeof(Command<>)
                                       select p).ToList();
        var referenceAssemblies = pluginCommandProperties
            .Select(x => x.DeclaringType.Assembly)
            .ToList();
        referenceAssemblies.AddRange(
            pluginCommandProperties
            .SelectMany(x => x.FieldType.GetGenericArguments())
            .Select(x => x.Assembly)
        );
        var buildInfo = new DynamicRepositoriesBuildInfo(
            pluginCommandFieldInfos: pluginCommandProperties,
            referencesAssemblies: referenceAssemblies.Distinct().ToList()
        );
        return buildInfo;
    }
    private static Assembly LoadDynamicRepositortyIntoAppDomain()
            {
                var buildInfo = GetDynamicRepositoriesBuildInfo();
    
                var csScriptBuilder = new StringBuilder();
                csScriptBuilder.AppendLine("using System;");
                csScriptBuilder.AppendLine("namespace App.Dynamic");
                csScriptBuilder.AppendLine("{");
                csScriptBuilder.AppendLine("    public class DynamicRepositories");
                csScriptBuilder.AppendLine("    {");
                foreach (var commandFieldInfo in buildInfo.PluginCommandFieldInfos)
                {
                    var commandNamespaceStr = commandFieldInfo.FieldType.Namespace;
                    var commandTypeStr = commandFieldInfo.FieldType.Name.Split('`')[0];
                    var commandGenericArgStr = commandFieldInfo.FieldType.GetGenericArguments().Single().FullName;
                    var commandFieldNameStr = commandFieldInfo.Name;
    
                    csScriptBuilder.AppendLine($"public {commandNamespaceStr}.{commandTypeStr}<{commandGenericArgStr}> {commandFieldNameStr} => (o) => ({commandGenericArgStr})o;");
                }
    
                csScriptBuilder.AppendLine("    }");
                csScriptBuilder.AppendLine("}");
    
                var sourceText = SourceText.From(csScriptBuilder.ToString());
                var parseOpt = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);
                var syntaxTree = SyntaxFactory.ParseSyntaxTree(sourceText, parseOpt);
                var references = new List<MetadataReference>
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                };
    
                references.AddRange(buildInfo.ReferencesAssemblies.Select(a => MetadataReference.CreateFromFile(a.Location)));
    
                var compileOpt = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                        optimizationLevel: OptimizationLevel.Release,
                        assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default);
    
                var compilation = CSharpCompilation.Create(
                        "DynamicRepository.dll",
                        new[] { syntaxTree },
                        references: references,
                        options: compileOpt);
    
                using (var memStream = new MemoryStream())
                {
                    var result = compilation.Emit(memStream);
                    if (result.Success)
                    {
                        var assembly = AppDomain.CurrentDomain.Load(memStream.ToArray());
    
                        return assembly;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
