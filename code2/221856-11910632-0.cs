    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication9
    {
      public class Program
      {
        public static void Main(String[] args)
        {
          var strings = GetStringPropertyValuesFromType(typeof(Properties.Resources), @"^website_.*");
          foreach (var s in strings)
            Console.WriteLine(s);
        }
    
        public static List<String> GetStringPropertyValuesFromType(Type type, String propertyNameMask)
        {
          var result = new List<String>();
          var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
          var regex = new Regex(propertyNameMask, RegexOptions.IgnoreCase | RegexOptions.Singleline);
    
          foreach (var propertyInfo in propertyInfos)
          {
            if (propertyInfo.CanRead &&
               (propertyInfo.PropertyType == typeof(String)) &&
               regex.IsMatch(propertyInfo.Name))
            {
              result.Add(propertyInfo.GetValue(type, null).ToString());
            }
          }
    
          return result;
        }
      }
    }
