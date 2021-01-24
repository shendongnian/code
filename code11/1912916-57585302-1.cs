    private static SyntaxNode GetDeclarationSyntaxNode(InvocationExpressionSyntax invocationSyntax, SemanticModel semanticModel)
    {
        var methodSymbol = (IMethodSymbol) semanticModel.GetSymbolInfo(invocationSyntax).Symbol;
        var syntaxReference = methodSymbol.DeclaringSyntaxReferences.FirstOrDefault();
        return syntaxReference?.GetSyntax();
    }
