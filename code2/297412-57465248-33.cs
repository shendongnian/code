    internal static class ScopeDebugInformationExtensions
    {
        public static IEnumerable<ScopeDebugInformation> GetInnerScopesRecursive(this ScopeDebugInformation scope)
        {
            yield return scope;
            foreach (var innerScope in scope.Scopes
                .SelectMany(innerScope => innerScope.GetInnerScopesRecursive()))
                yield return innerScope;
        }
    }
