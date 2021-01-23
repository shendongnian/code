    Assembly assembly = null;
    var className = "System.Boolean";
    var assemblyName = "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
         
    foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
    {
        if (a.FullName == assemblyName)
        {
            assembly = a;
            break;
        }
    }
    if (assembly != null)
    {
        System.Runtime.Remoting.ObjectHandle obj =
            System.Activator.CreateInstance(assemblyName, className);
    }
