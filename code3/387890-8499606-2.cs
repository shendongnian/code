    var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetTypes()
                    where type.Name == className && type.GetMethods().Any(m => m.Name == methodName)
                    select type).FirstOrDefault();
    if (type == null) throw new InvalidOperationException("Valid type not found.");
    object instance = Activator.CreateInstance(type);
