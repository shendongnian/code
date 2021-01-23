    object instantiatedType =
       Activator.CreateInstance(typeToInstantiate,
       System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance,
       null, new object[] {parameter}, null);
