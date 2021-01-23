        public class DataProviderFactory
    {
        public IDataProvider GetProvider(string assemblyName, string type, string connectionString)
        {
            var assembly = System.Reflection.Assembly.Load(new AssemblyName(assemblyName));
            return (IDataProvider)assembly.CreateInstance(type, true, BindingFlags.CreateInstance, null, new object[]{ connectionString }, null, null);
        }
    }
