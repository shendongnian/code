    Assembly a = Assembly.LoadWithPartialName("...");
    Type[] types = a.GetTypes();
    foreach (Type type in types)
    {
        MemberInfo[] members = type.GetMembers();
        foreach (MemberInfo member in members)
        {
            Console.WriteLine(type.Name+"."+member.Name);
        }
    }
