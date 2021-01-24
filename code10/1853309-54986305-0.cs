    foreach (MethodDeclarationSyntax method in methodDeclarations)
    {
        var symbol = semanticModel.GetEnclosingSymbol(method.SpanStart);
        var assembly = symbol.ContainingAssembly;
        var assemblyName = assembly.Identity.Name;
    }
