    public static class MethodDefinitionExtensions
    {
        public static MethodDefinition GetMethodDefinition(this MethodInfo info) =>
            AssemblyDefinition
            .ReadAssembly(info.DeclaringType.Assembly.Location)
            .Modules
            .SelectMany(module => module.GetTypes())
            .Single(t => t.FullNameMatches(info.DeclaringType))
            .Methods
            .FirstOrDefault(method =>
                method.Name.Equals(info.Name) &&
                method.ReturnType.FullName.Equals(info.ReturnType.FullName) &&
                method.Parameters.Select(parameter => parameter.ParameterType.FullName)
                      .SequenceEqual(info.GetParameters().Select(parameter => parameter.ParameterType.FullName)));
    }
