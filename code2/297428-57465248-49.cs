    public static class MethodDefinitionExtensions
    {
        public static MethodDefinition GetMethodDefinition(this MethodBase info) =>
            AssemblyDefinition
            .ReadAssembly(info.DeclaringType.Assembly.Location)
            .Modules
            .SelectMany(module => module.GetTypes())
            .Single(type => type.FullNameMatches(info.DeclaringType))
            .Methods
            .FirstOrDefault(method =>
                method.Name.Equals(info.Name) &&
                method.ReturnType.FullName.Equals(info.GetReturnType().FullName) &&
                method.Parameters.Select(parameter => parameter.ParameterType.FullName)
                      .SequenceEqual(info.GetParameters().Select(parameter => parameter.ParameterType.FullName)));
    }
