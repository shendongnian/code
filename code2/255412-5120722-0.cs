    var instances = (from assembly in assemblies
                     from type in assembly
                     where !type.IsAbstract && 
                           type.IsClass &&
                           type.IsPublic &&
                           !type.IsGenericType &&
                           typeof(IExample).IsAssignableFrom(type)
                     let ctor = type.GetConstructor(Type.EmptyTypes)
                     where ctor != null && ctor.IsPublic
                     select (IExample) Activator.CreateInstance(type))
                    .ToList();
