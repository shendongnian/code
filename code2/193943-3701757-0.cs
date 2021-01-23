       var interfaces = (from fileName in files
                         select Assembly.LoadFile(fileName)
                         into assembly
                         select assembly.GetTypes()
                         into typesInAssembly
                         from interfacesInType in typesInAssembly.Select(type => type.GetInterfaces())
                         from interfaceInType in interfacesInType
                         select interfaceInType)
                         .Distinct()
                         .OrderBy( i => i.Name);
