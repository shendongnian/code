    Assembly asm = Assembly.Load("mscorlib.dll");
    foreach (Type type in asm.GetTypes())
    {
        foreach (MemberInfo mem in type.GetMembers())
        {
            if ((mem.MemberType == MemberTypes.Property) && (mem.Name == "Capacity"))
                Console.WriteLine(type);
        }
    }
