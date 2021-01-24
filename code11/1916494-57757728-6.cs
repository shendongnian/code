    public partial class AmbiguityAnalysisAnalyzer
    {
        private static IEnumerable<INamedTypeSymbol> GetAllTypes(Compilation compilation) =>
            GetAllTypes(compilation.GlobalNamespace);
        private static IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol @namespace)
        {
            foreach (var type in @namespace.GetTypeMembers())
                foreach (var nestedType in GetNestedTypes(type))
                    yield return nestedType;
            foreach (var nestedNamespace in @namespace.GetNamespaceMembers())
                foreach (var type in GetAllTypes(nestedNamespace))
                    yield return type;
        }
        private static IEnumerable<INamedTypeSymbol> GetNestedTypes(INamedTypeSymbol type)
        {
            yield return type;
            foreach (var nestedType in type.GetTypeMembers()
                .SelectMany(nestedType => GetNestedTypes(nestedType)))
                yield return nestedType;
        }
        private static AttributeSyntax[] GetAllAttribute(SemanticModelAnalysisContext context) =>
            context
            .SemanticModel
            .SyntaxTree
            .GetRoot()
            .DescendantNodes()
            .OfType<AttributeSyntax>()
            .ToArray();
        private static IEnumerable<Diagnostic> GetAmbiguities(INamedTypeSymbol[] types, AttributeSyntax[] attributes)
        {
            foreach (var attribute in attributes)
            {
                var usings = GetUsings(attribute.SyntaxTree);
                var ambiguities = GetAmbiguities(usings, types, attribute);
                if (ambiguities.Length < 2)
                    continue;
                var suggestedAttributes = GetAttributes(ambiguities);
                var suggestedNonAttributes = GetNonAttributes(ambiguities);
                var parts =
                    new[]
                    {
                        GetPart("attributes", suggestedAttributes),
                        GetPart("non attributes", suggestedNonAttributes)
                    }
                    .Where(part => !part.Equals(string.Empty));
                var name = (attribute.Name as IdentifierNameSyntax)?.Identifier.ValueText;
                var suggestions =
                    name == null ?
                    ImmutableDictionary<string, string>.Empty :
                    suggestedAttributes.Select(type => GetFullyQualifiedName(type))
                        .ToImmutableDictionary(type => type, type => name);
                var message = string.Join(" and ", parts);
                yield return Diagnostic.Create(Rule, attribute.GetLocation(), suggestions, attribute.Name, message);
            }
        }
    }
