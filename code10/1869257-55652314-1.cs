    public static int GetBuildType(string AssemblyName)
    {
        Assembly assm = Assembly.LoadFrom(AssemblyName);
        object[] attributes = assm.GetCustomAttributes(typeof(DebuggableAttribute), false);
        if (attributes.Length == 0)
        {
            Console.WriteLine(String.Format("{0} is a RELEASE Build....", AssemblyName));
            return 0;
        }
    
        foreach (Attribute attr in attributes)
        {
            if (attr is DebuggableAttribute)
            {
                DebuggableAttribute d = attr as DebuggableAttribute;
                Console.WriteLine(String.Format("Run time Optimizer is enabled : {0}", !d.IsJITOptimizerDisabled));
                Console.WriteLine(String.Format("Run time Tracking is enabled : {0}", d.IsJITTrackingEnabled));
    
                if (d.IsJITOptimizerDisabled == true)
                {
                    Console.WriteLine(String.Format("{0} is a DEBUG Build....", AssemblyName));
                    return 1;
                }
                else
                {
                    Console.WriteLine(String.Format("{0} is a RELEASE Build....", AssemblyName));
                    return 0;
                }
            }
        }
        return 3;
    }
