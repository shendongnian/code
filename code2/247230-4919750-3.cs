    var className = "System.Boolean";
    var assemblyName = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    var assembly = (from a in assemblies
                    where a.FullName == assemblyName
                    select a).SingleOrDefault();
    if (assembly != null)
    {
        System.Runtime.Remoting.ObjectHandle obj = 
            System.Activator.CreateInstance(assemblyName, className);             
    }
