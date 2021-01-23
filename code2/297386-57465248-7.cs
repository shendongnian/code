    public class MonoCecilReader : ILocalsReader
    {
        public VariableInfo[] Read(MethodInfo info)
        {
            var il = info.GetMethodBody().LocalVariables.ToArray();
            var file = info.DeclaringType.Assembly.Location;
            var methodDefinition =
                AssemblyDefinition
                .ReadAssembly(file)
                .Modules
                .SelectMany(module => module.Types)
                .Where(type => type.FullName.Equals(info.DeclaringType.FullName))
                .SelectMany(type => type.Methods)
                .FirstOrDefault(method =>
                    method.Name.Equals(info.Name) &&
                    method.ReturnType.FullName.Equals(info.ReturnType.FullName) &&
                    method.Parameters.Select(parameter => parameter.ParameterType.FullName)
                          .SequenceEqual(info.GetParameters().Select(parameter => parameter.ParameterType.FullName)));
            methodDefinition.Module.ReadSymbols();
            var pdb = Path.ChangeExtension(file, "pdb");
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
