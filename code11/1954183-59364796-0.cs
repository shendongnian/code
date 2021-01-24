    Assembly assembly = null;
    string[] sourceStringArray = null;// set this to hold the arrary of source strings
    List<SyntaxTree> syntaxTreeList = new List<SyntaxTree>();
    foreach (string sourceString in sourceStringArray)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceString);
        syntaxTreeList.Add(syntaxTree);
    }
    
    string assemblyName = Path.GetRandomFileName();
    AppDomain currentDomain = AppDomain.CurrentDomain;
    List<MetadataReference> metadataReferenceList = new List<MetadataReference>();
    Assembly[] assemblyArray = currentDomain.GetAssemblies();
    foreach (Assembly domainAssembly in assemblyArray)
    {
        try
        {
            AssemblyMetadata assemblyMetadata = AssemblyMetadata.CreateFromFile(domainAssembly.Location);
            MetadataReference metadataReference = assemblyMetadata.GetReference();
            metadataReferenceList.Add(metadataReference);
        }
        catch (Exception e)
        {
            Log.DebugFormat("failed to get MetadataReference {0}", e.Message);
        }
    }
    
    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName,
        syntaxTrees: syntaxTreeList,
        references: metadataReferenceList,
        options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    using (var ms = new MemoryStream())
    {
        EmitResult result = compilation.Emit(ms);
        if (!result.Success)
        {
            IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);
            foreach (Diagnostic diagnostic in failures)
            {
                /* Process failures */
            }
        }
        else
        {
            ms.Seek(0, SeekOrigin.Begin);
            assembly = Assembly.Load(ms.ToArray());
        }
    }
