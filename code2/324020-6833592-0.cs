    var resolver = new DefaultAssemblyResolver ();
    resolver.AddSearchDirectory ("path/to/AssemblyA");
    resolver.AddSearchDirectory ("path/to/AssemblyB");
    
    var a = AssemblyDefinition.ReadAssembly (
    	"path/to/AssemblyA/AssemblyA.dll",
    	new ReaderParameters { AssemblyResolver = resolver });
    
    var b = AssemblyDefinition.ReadAssembly (
    	"path/to/AssemblyB/AssemblyB.dll",
    	new ReaderParameters { AssemblyResolver = resolver });
