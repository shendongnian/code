    using System.Collections.Generic;
    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var dic = new Dictionary<string, object> {{"Test", 1}};
                var result = dic.Get("Test");
            }
        }
        public static class MyExtensions
        {
            public static object Get(this IDictionary<string, object> dict, string key)
            {
                if (dict.TryGetValue(key, out object value))
                {
                    return value;
                }
                return null;
            }
            public static T Get<T>(this IDictionary<string, T> dict, string key)
            {
                if (dict.TryGetValue(key, out T value))
                {
                    return value;
                }
                return default(T);
            }
        }
    }
