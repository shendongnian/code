    public partial class AmbiguityAnalysisAnalyzer
    {
        private static string GetFullyQualifiedName(INamedTypeSymbol type)
        {
            var @namespace = GetFullName(type.ContainingNamespace, n => !n.IsGlobalNamespace, n => n.ContainingNamespace);
            var name = GetFullName(type, t => t != null, t => t.ContainingType);
            if (!@namespace.Equals(string.Empty, StringComparison.Ordinal))
                return $"{@namespace}.{name}";
            return name;
        }
        private static string[] GetUsings(SyntaxTree syntaxTree) =>
            syntaxTree
            .GetCompilationUnitRoot()
            .Usings.Select(GetUsingString)
            .Concat(new[] { string.Empty })
            .ToArray();
        private static string GetUsingString(UsingDirectiveSyntax @using) =>
            GetUsingStringFromName(@using.Name);
        private static string GetUsingStringFromName(NameSyntax name)
        {
            if (name is IdentifierNameSyntax identifierName)
                return identifierName.Identifier.ValueText;
            if (name is QualifiedNameSyntax qualifiedName)
                return $"{GetUsingStringFromName(qualifiedName.Left)}.{GetUsingStringFromName(qualifiedName.Right)}";
            throw new ArgumentException($"Argument '{nameof(name)}' was of unexpected type.");
        }
        private static INamedTypeSymbol[] GetAmbiguities(IEnumerable<string> usings, IEnumerable<INamedTypeSymbol> types, AttributeSyntax attribute) =>
            types
            .Where(t => attribute.Name is IdentifierNameSyntax name &&
                        NameMatches(t, name) &&
                        NamespaceInUsings(usings, t))
            .ToArray();
        private static bool NamespaceInUsings(IEnumerable<string> usings, INamedTypeSymbol type) =>
            usings.Contains(GetFullName(type.ContainingNamespace, n => !n.IsGlobalNamespace, n => n.ContainingNamespace));
        private static bool NameMatches(INamedTypeSymbol type, IdentifierNameSyntax nameSyntax)
        {
            var isVerbatim = nameSyntax.Identifier.Text.StartsWith("@");
            var name = nameSyntax.Identifier.ValueText;
            var names = isVerbatim ? new[] { name } : new[] { name, name + "Attribute" };
            var fullName = GetFullName(type, t => t != null, t => t.ContainingType);
            var res = names.Contains(fullName, StringComparer.Ordinal);
            return res;
        }
        private static string GetFullName<TSymbol>(TSymbol symbol, Func<TSymbol, bool> condition, Func<TSymbol, TSymbol> transition) where TSymbol : ISymbol
        {
            var values = new List<string>();
            while (condition(symbol))
            {
                values.Add(symbol.Name);
                symbol = transition(symbol);
            }
            values.Reverse();
            return string.Join(".", values);
        }
        private static IEnumerable<INamedTypeSymbol> GetAttributes(IEnumerable<INamedTypeSymbol> types) =>
            types.Where(type => IsAttribute(type));
        private static IEnumerable<INamedTypeSymbol> GetNonAttributes(IEnumerable<INamedTypeSymbol> types) =>
            types.Where(type => !IsAttribute(type));
        private static bool IsAttribute(INamedTypeSymbol type)
        {
            var @namespace = type.ContainingNamespace.Name;
            var name = type.Name;
            if (@namespace.Equals("System", StringComparison.Ordinal) &&
                name.Equals("Attribute", StringComparison.Ordinal))
                return true;
            if (@namespace.Equals("System", StringComparison.Ordinal) &&
                name.Equals("Object", StringComparison.Ordinal))
                return false;
            return IsAttribute(type.BaseType);
        }
        private static string GetPart(string description, IEnumerable<INamedTypeSymbol> types)
        {
            var part = string.Join(", ", types.Select(type => $"'{type}'"));
            if (!part.Equals(string.Empty))
                part = $"{description} {part}";
            return part;
        }
    }
