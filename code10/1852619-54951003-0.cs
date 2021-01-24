    private void AnalyzeNode(SyntaxNodeAnalysisContext context)
	{
		var invocationExpr = (InvocationExpressionSyntax)context.Node;
		var memberAccessExpr = invocationExpr.Expression as MemberAccessExpressionSyntax;
		var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol as IMethodSymbol;
		var namespace= memberSymbol?.ContainingNamespace;
        var assemblyName = memberSymbol?.ContainingAssembly;
	}
