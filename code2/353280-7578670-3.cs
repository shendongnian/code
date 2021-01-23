    var root = (CompilationUnitSyntax)tree.GetRoot();
    var compilation = CSharpCompilation.Create("HelloTDN")
                .AddReferences(references: new[] { MetadataReference.CreateFromAssembly(typeof(object).Assembly) })
                .AddSyntaxTrees(tree);
    var model = compilation.GetSemanticModel(tree);
    var nameInfo = model.GetSymbolInfo(root.Usings[0].Name);
    var systemSymbol = (INamespaceSymbol)nameInfo.Symbol;
    foreach (var ns in systemSymbol.GetNamespaceMembers())
    {
       Console.WriteLine(ns.Name);
    }
