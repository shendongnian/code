    internal static class SymbolScopeExtensions
    {
        public static IEnumerable<ISymbolScope> GetInnerScopesRecursive(this ISymbolScope scope)
        {
            yield return scope;
            foreach (var innerScope in scope.GetChildren()
                .SelectMany(innerScope => innerScope.GetInnerScopesRecursive()))
                yield return innerScope;
        }
    }
