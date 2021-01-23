    public class MicrosoftDebuggingReader : ILocalsReader
    {
        public VariableInfo[] Read(MethodBase info)
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
