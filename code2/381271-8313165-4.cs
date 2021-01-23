    public sealed class StubLoader: MarshalByRefObject, IStubLoader
        {
            public object CreateInstanceFromAndUnwrap(byte[] assemblyBytes, string typeName)
            {
                var assembly = Assembly.Load(assemblyBytes);
                return assembly.CreateInstance(typeName);
            }
        }
