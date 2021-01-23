    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            MethodInfo method = typeof(int).GetMethod
                ("TryParse", new Type[] { typeof(string),
                                          typeof(int).MakeByRefType() });
            // Second value here will be ignored, but make sure it's the right type
            object[] args = new object[] { "10", 0 };
            
            object result = method.Invoke(null, args);
            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("args[1]: {0}", args[1]);
        }
    }
