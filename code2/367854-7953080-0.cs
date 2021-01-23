    internal class FromLoadedAssemblyBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {            
                Assembly assembly = Assembly.Load(assemblyName);
                return assembly.GetType(typeName);
            }
        }
