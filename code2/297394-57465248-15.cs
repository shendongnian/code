    internal static class ScopeDebugInformationExtensions
    {
        public static IEnumerable<ScopeDebugInformation> GetInnerScopesRecursive(this ScopeDebugInformation scope)
        {
            yield return scope;
            foreach (var inner in scope.Scopes
                .SelectMany(i => i.GetInnerScopesRecursive()))
                yield return inner;
        }
    }
