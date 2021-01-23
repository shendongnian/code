    public class PlugInFactory<T>
    {
        public T CreatePlugin(string path)
        {
            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                foreach (Type assemblyType in Assembly.LoadFrom(file).GetTypes())
                {
                    Type interfaceType = assemblyType.GetInterface(typeof(T).FullName);
                    if (interfaceType != null)
                    {
                        return (T)Activator.CreateInstance(assemblyType);
                    }
                }
            }
            return default(T);
        }
    }
