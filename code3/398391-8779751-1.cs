    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            object[] arguments = new object[1];
            MethodInfo method = typeof(Test).GetMethod("SampleMethod");
            method.Invoke(null, arguments);
            Console.WriteLine(arguments[0]); // Prints Hello
        }
        
        public static void SampleMethod(out string text)
        {
            text = "Hello";
        }
    }
