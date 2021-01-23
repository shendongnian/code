    using System;
    using System.Reflection;
    public class Example
    {
        public static void Main()
        {
            Console.WriteLine("The version of the currently executing assembly is: {0}",
                              typeof(Example).Assembly.GetName().Version);
        }
    }
    /* This example produces output similar to the following:
       The version of the currently executing assembly is: 1.1.0.0
