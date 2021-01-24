    class AssemblyHelper
    {
        public static bool AssemblyIsInGAC(string assemblyName)
        {
            try
            {
                var assembly = Assembly.Load(assemblyName);
                return assembly.FullName == assemblyName && // makes "mscorlib, Version=wrong version ..." work properly
                    assembly.GlobalAssemblyCache;
            }
            catch(FileNotFoundException)
            {
                return false;
            }
        }
    }
