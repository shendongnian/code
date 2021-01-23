        var assembly = Assembly.GetExecutingAssembly();
        var names = (from type in assembly.GetTypes()
                     from method in type.GetMethods(
                       BindingFlags.Public | BindingFlags.NonPublic |
                       BindingFlags.Instance | BindingFlags.Static)
                     select type.FullName + ":" + method.Name).Distinct().ToList();
