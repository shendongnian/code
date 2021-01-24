public void Add(Action<Cursor> action)
{
    // Get the assembly in which the lambda resides
    var asm = Assembly.GetCallingAssembly();
    var file = asm.Location;
    
    // Create a resolver (a callback for resolving referenced assemblies during decompilation)
    var resolver = new CustomAssemblyResolver(asm);
    // Create an instance of decompiler
    var decompiler = new CSharpDecompiler(file, resolver, new DecompilerSettings());
    // Get an "EntityHandle" instance for the lambda's underlying method
    var method = MetadataTokenHelpers.TryAsEntityHandle(action.Method.MetadataToken); 
    var ast = decompiler.Decompile(new List<EntityHandle>() { method.Value });
}
As I mentioned, you provide the `CSharpDecompiler` instance with a resolver (`IAssemblyResolver`) whose job is to load referenced assemblies during the decompilation process.  
`ICSharpCode.Decompiler` has a `UniversalAssemblyResolver` ([source][2])
which does the job by searching common folders in the file system (it receives a framework version to know where to search).  I didn't like it as it assumes too much and requires too much information (I don't always know the framework or other parts of my runtime), so I've created my own resolver which traverses the assemblies graph (starting from the calling assembly).
class CustomAssemblyResolver : IAssemblyResolver
{
    private Dictionary<string, Assembly> _references;
    public CustomAssemblyResolver(Assembly asm)
    {
        _references = new Dictionary<string, Assembly>();
        var stack = new Stack<Assembly>();
        stack.Push(asm);
        while (stack.Count > 0)
        {
            var top = stack.Pop();
            if (_references.ContainsKey(top.FullName)) continue;
            _references[top.FullName] = top;
            var refs = top.GetReferencedAssemblies();
            if (refs != null && refs.Length > 0)
            {
                foreach (var r in refs)
                {
                    stack.Push(Assembly.Load(r));
                }
            }
        }
        ;
    }
    public PEFile Resolve(IAssemblyReference reference)
    {
        var asm = _references[reference.FullName];
        var file = asm.Location;
        return new PEFile(file, new FileStream(file, FileMode.Open, FileAccess.Read), PEStreamOptions.Default, MetadataReaderOptions.Default);
    }
    public PEFile ResolveModule(PEFile mainModule, string moduleName)
    {
        var baseDir = Path.GetDirectoryName(mainModule.FileName);
        var moduleFileName = Path.Combine(baseDir, moduleName);
        if (!File.Exists(moduleFileName))
        {
            throw new Exception($"Module {moduleName} could not be found");
        }
        return new PEFile(moduleFileName, new FileStream(moduleFileName, FileMode.Open, FileAccess.Read), PEStreamOptions.Default, MetadataReaderOptions.Default);
    }
}
I don't know if it's the best approach for all use cases, but It works great for me, at least so far.
  [1]: https://github.com/icsharpcode/ILSpy
  [2]: https://github.com/icsharpcode/ILSpy/blob/master/ICSharpCode.Decompiler/Metadata/UniversalAssemblyResolver.cs
