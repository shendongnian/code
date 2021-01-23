    Assembly assembly = Assembly.ReflectionOnlyLoadFrom("System.Core.dll");
    Type[] types;
    try
    {
        types = assembly.GetTypes();
    }
    catch (ReflectionTypeLoadException ex)
    {
        types = ex.Types;
    }
