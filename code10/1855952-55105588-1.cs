    static void Main(string[] args)
    {
        var assembly = Assembly.GetExecutingAssembly();
        foreach (var type in assembly.GetTypes())
        {
            var methodInfos = type.GetMethods();
            // looking at all the methods, not yet narrowing it down to those
            // with the attribute.
            foreach (var mInfo in methodInfos)
            {
                // We don't just want to know if it has the attribute.
                // We need to get the attribute.
                var executeMeParameter = mInfo.GetCustomAttribute<ExecuteMe>();
                // If it's null the method doesn't have the attribute. 
                // Ignore this method.
                if (executeMeParameter == null) continue;
                // We don't need to create the instance until we know that we're going
                // to invoke the method.
                object act = Activator.CreateInstance(type);
                // Pass the args property of the attribute (an array of objects)
                // as the argument list for the method.
                mInfo.Invoke(act, new object[]{executeMeParameter.args});
            }
            if (type.IsClass)
                Console.WriteLine(type.FullName);
        }
        Console.ReadLine();
    }
