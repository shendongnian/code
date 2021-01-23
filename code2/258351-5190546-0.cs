        Type t = typeof(System.Nullable);
        System.Reflection.Assembly a = System.Reflection.Assembly.GetAssembly("System.DLL");
        Type[] types = a.GetTypes();
        foreach (Type type in types)
        {
            if (type.IsSubclassOf(t))
                Console.Write(type.ToString());
        }
