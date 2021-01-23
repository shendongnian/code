    Assembly a = Assembly.LoadWithPartialName("...");
    Type[] types = a.GetTypes();
    foreach (Type type in types)
    {
        if (!type.IsPublic)
        {
            continue;
        }
        MemberInfo[] members = type.GetMembers(BindingFlags.Public
                                              |BindingFlags.Instance
                                              |BindingFlags.InvokeMethod);
        foreach (MemberInfo member in members)
        {
            Console.WriteLine(type.Name+"."+member.Name);
        }
    }
