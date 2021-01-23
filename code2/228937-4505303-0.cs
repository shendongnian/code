    Type type = typeof(Foo);
    
    foreach ( var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)) {
        var getMethod = property.GetGetMethod(false);
        if (getMethod.GetBaseDefinition() == getMethod) {
            Console.WriteLine(getMethod);
        }
    }
