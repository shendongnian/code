    using System;
    namespace System.Runtime.CompilerServices
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class ExtensionAttribute : Attribute
        {
            public ExtensionAttribute()
            {
    
            }
        }
    }
    
    public static class Helper
    {
        public static float ToFloat(this string input)
        {
            float result;
            return float.TryParse(input, out result) ? result : 0;
        }
    }
    
    class Program
    {
        static void Main()
        {
            string foo = "123";
            Console.WriteLine(foo.ToFloat());
        }
    }
