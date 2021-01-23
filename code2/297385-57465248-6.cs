    public class MicrosoftDebuggingReader : ILocalsReader
    {
        public VariableInfo[] Read(MethodInfo info)
        {
            var il = info.GetMethodBody().LocalVariables.ToArray();
            return SymbolAccess
                .GetReaderForFile(info.DeclaringType.Assembly.Location)
                .GetMethod(new SymbolToken(info.MetadataToken))
                .RootScope
                .GetInnerScopesRecursive()
                .SelectMany(scope => scope.GetLocals())
                .Select(local =>
                    new VariableInfo(local.AddressField1,
                                     il[local.AddressField1].LocalType,
                                     local.Name))
               .ToArray();
        }
    }
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
