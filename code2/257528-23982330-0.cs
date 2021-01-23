        public sealed class DeserializationBinder : SerializationBinder
    {
        private readonly string _typeName;
        private readonly Assembly _assembly;
        public DeserializationBinder(Assembly assembly, string typeName)
        {
            _typeName = typeName;
            _assembly = assembly;
        }
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;
            if (!assemblyName.Contains("System") && !assemblyName.Contains("mscorlib"))
            {
                String currentAssembly = _assembly.FullName;
                assemblyName = currentAssembly;
                typeName = _typeName;
            }
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));
            return typeToDeserialize;
        }
    }
