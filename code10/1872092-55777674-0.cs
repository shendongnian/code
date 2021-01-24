      public static bool IsDeclareInMetadata(this SemanticModel semanticModel, SyntaxNode node)
      {
   		var info = semanticModel.GetSymbolInfo(node);
   		return !(info.Symbol is null) && info.Symbol.DeclaringSyntaxReferences.IsDefaultOrEmpty && !info.Symbol.IsImplicitlyDeclared;
      }
