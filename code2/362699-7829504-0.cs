    foreach (ParameterInfo pi in method.GetParameters())
    {
        if (pi.IsOptional)
        {
            Console.WriteLine(pi.Name + ": " + pi.DefaultValue);
        }
    }
