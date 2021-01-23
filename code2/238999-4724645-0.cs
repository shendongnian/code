    using System;
    using System.Reflection;
    
    class Example
    {
        static void Main()
        {
            var assemblyName = Assembly.GetExecutingAssembly().FullName;
            var o = Activator.CreateInstance(assemblyName, "Example").Unwrap();
        }
    }
