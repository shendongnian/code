    SemanticModel model = compilation.GetSemanticModel(tree);           
    var methodSyntax = tree.GetRoot().DescendantNodes()
        .OfType<MethodDeclarationSyntax>()
        .FirstOrDefault(x => x.Identifier.Text == "TestMethod");
    var memberAccessSyntax = methodSyntax.DescendantNodes()
        .OfType<MemberAccessExpressionSyntax>()
        .FirstOrDefault(x => x.Name.Identifier.Text == "CreateSomeObject");
    var accessSymbol = model.GetSymbolInfo(memberAccessSyntax);
    IMethodSymbol methodSymbol = (Microsoft.CodeAnalysis.IMethodSymbol)accessSymbol.Symbol;
    ITypeSymbol returnType = methodSymbol.ReturnType;
