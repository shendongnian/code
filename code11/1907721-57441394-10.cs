    public static class ExceptionHelper<TException> where TException : Exception
    {
        private static readonly string typeName = typeof(TException).FullName;
        public static void ThrowIfDetected(Assembly assembly)
        {
            var definition = AssemblyDefinition.ReadAssembly(assembly.Location);
            var exceptions = CreateExceptions(definition);
            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }
        public static void ThrowIfDetected(params Assembly[] assemblies) =>
            ThrowIfDetected(assemblies as IEnumerable<Assembly>);
        public static void ThrowIfDetected(IEnumerable<Assembly> assemblies)
        {
            var exceptions = CreateExceptions(assemblies);
            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }
        private static IEnumerable<Exception> CreateExceptions(IEnumerable<Assembly> assemblies) =>
            assemblies.Select(assembly => AssemblyDefinition.ReadAssembly(assembly.Location))
                      .SelectMany(definition => CreateExceptions(definition));
        private static IEnumerable<Exception> CreateExceptions(AssemblyDefinition definition)
        {
            var methods =
                    definition.Modules
                              .SelectMany(m => m.GetTypes())
                              .SelectMany(t => t.Methods)
                              .Where(m => m.HasBody);
            foreach (var method in methods)
            {
                var instructions = method.Body.Instructions
                    .Where(i => i.OpCode.Code == Code.Newobj && // new object is created
                                ((MethodReference)i.Operand).DeclaringType.FullName == typeName && // the object is 'TException'
                                i.Next.OpCode.Code == Code.Throw); // and it's immediately thrown
                foreach (var i in instructions)
                {
                    var message = $"{definition.FullName} {method.FullName} offset {i.Offset} throws {typeName}";
                    yield return new Exception(message);
                }
            }
        }
    }
