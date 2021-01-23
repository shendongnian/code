    static Program()
    {
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            foreach (var method in type.GetMethods(BindingFlags.DeclaredOnly |
                                BindingFlags.NonPublic |
                                BindingFlags.Public | BindingFlags.Instance |
                                BindingFlags.Static))
            {
                if ((method.Attributes & MethodAttributes.Abstract) == MethodAttributes.Abstract|| method.ContainsGenericParameters)
                {
                    continue;
                }
                System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod(method.MethodHandle);
            }
        }
        Console.WriteLine("jitted!");
    }
