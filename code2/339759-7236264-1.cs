    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test = "0.0";
                float f = test.ToFloat();
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
    }
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
