       private bool IsAssemblySigned()
        {
            var assembly = Assembly.GetAssembly(GetType());
            var assemblyName = assembly.GetName();
            var key = assemblyName.GetPublicKey();
            return key.Length > 0;
        }
