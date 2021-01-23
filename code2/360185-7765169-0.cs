    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace ConsoleApplication1
    {
    
        public enum YourEnum
        {
            Apples = 1,
            Pears = 2,
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var value in (YourEnum[])Enum.GetValues(typeof(YourEnum)))
                {
                    int v = value.GetValue();
                    Console.WriteLine("{0} = {1} (int)", value.ToString(), v);
    
                    string s = value.GetString();
                    Console.WriteLine("{0} = {1} (string)", value.ToString(), s);
                }
                Console.ReadLine();
    
                //Results:
    
                //Apples = 1 (int)
                //Apples = 1 (string)
                //Pears = 2 (int)
                //Pears = 2 (string)
            }
        }
    
        public static class EnumExtensions
        {
            public static int GetValue(this Enum value) 
            {
                return Convert.ToInt32(value);
            }
    
            public static string GetString(this Enum value)
            {
                return Convert.ToInt32(value).ToString();
            }
        }
    
    }
