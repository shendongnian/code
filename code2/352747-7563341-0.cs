        Type t = typeof(Test);
        int max = 0;
        Type result = null;
        foreach (Type type in t.GetInterfaces())
        {
            int len = type.GetInterfaces().Length;
            if (len > max)
            {
                max = len;
                result = type;
            }
        }
        if (result != null)
            Console.WriteLine(result.FullName);
