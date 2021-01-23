        foreach ( MemberInfo memberInfo in members.Where(p => p.MemberType == MemberTypes.Property))
        {
        	Console.WriteLine("Name: {0}", memberInfo.Name); // Name: MyField
            Console.WriteLine("Member Type: {0}", memberInfo.MemberType); // Member Type: Property
        }
