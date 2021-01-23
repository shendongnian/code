    public MyType LoadTypeFromAssembly(string assemblyPath, string typeName)
    {
                var assembly = Assembly.LoadFrom(assemblyPath);
                if (assembly == null)
                    throw new InvalidOperationException("Could not load the specified assembly '" + assemblyPath + "'");
                var type = assembly.GetType(typeName);
                if (type == null)
                    throw new InvalidOperationException("The specified class '" + class + "' was not found in assembly '" + filter.Assembly + "'");
                var instance = (MyType)Activator.CreateInstance(type);
                return instance;
    }
