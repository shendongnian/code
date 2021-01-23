    Object Creator(string assemblyname, string classname) 
    {
       System.Type objType = System.Type.GetType(assemblyname + "." + classname);
       Return Activator.CreateInstance(objType);
    }
