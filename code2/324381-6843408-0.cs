    // Assembly is a System.Reflection.Assembly
    public string GetAssemblyGUID(Assembly assembly)
    {
        object[] objects = assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
        if (objects.Length > 0)
            return ((System.Runtime.InteropServices.GuidAttribute)objects[0]).Value;
        else
            return null;
    }
