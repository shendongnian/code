    using System;
    using System.Reflection;
    
    class Example
    {
        static void Main()
        {
            var type = Assembly.GetExecutingAssembly().GetType("Example");
            var o = Activator.CreateInstance(type);
        }
    }
