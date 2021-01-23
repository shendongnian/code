        Type t = typeof(Test);
        int max = 0;
        List<Type> results = new List<Type>();
        foreach (Type type in t.GetInterfaces())
        {
            int len = type.GetInterfaces().Length;
            if (len > max)
            {
                max = len;
                results.Add(type);
            }
        }
        if (results.Count > 0)
            foreach (Type type in results)
                Console.WriteLine(type.FullName);
