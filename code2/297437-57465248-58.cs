    public class MonoCecilReader : ILocalsReader
    {
        public VariableInfo[] Read(MethodBase info)
        {
            var il = info.GetMethodBody().LocalVariables.ToArray();
            var methodDefinition = info.GetMethodDefinition();
            methodDefinition.Module.ReadSymbols();
            var pdb = Path.ChangeExtension(info.DeclaringType.Assembly.Location, "pdb");
            new PdbReaderProvider().GetSymbolReader(methodDefinition.Module, pdb)
                                   .Read(methodDefinition);
            return methodDefinition
                .DebugInformation
                .Scope
                .GetInnerScopesRecursive()
                .SelectMany(scope => scope.Variables)
                .Select(local =>
                    new VariableInfo(local.Index,
                                     il[local.Index].LocalType,
                                     local.Name))
                .ToArray();
        }
    }
