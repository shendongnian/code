    try
    {
        return Assembly.LoadFrom(assemblyName);
    }
    catch (Exception ex)
    {
        var reflection = ex as ReflectionTypeLoadException;
        if (reflection != null)
        {
            foreach (var exception in reflection.LoaderExceptions)
            {
                // log / inspect the message
            }
            return null;
        }
    }
