    public class MonoCecilReader : ILocalsReader
    {
        public VariableInfo[] Read(MethodInfo info)
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
                .SelectMany(i => i.Variables)
                .Select(i =>
                    new VariableInfo(i.Index,
                                     il[i.Index].LocalType,
                                     i.Name))
                .ToArray();
        }
    }
