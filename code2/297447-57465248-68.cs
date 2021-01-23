    public class MonoCecilReader : ILocalsReader
    {
        public VariableInfo[] Read(MethodBase info)
        {
            var method = info.GetMethodDefinition();
            method.Module.ReadSymbols();
            var pdb = Path.ChangeExtension(info.DeclaringType.Assembly.Location, "pdb");
            new PdbReaderProvider().GetSymbolReader(method.Module, pdb)
                                   .Read(method);
            var il = info.GetMethodBody().LocalVariables;
            return Read(method, il);
        }
        public VariableInfo[] Read(MethodDefinition method, IList<LocalVariableInfo> il)
        {
            return method
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
