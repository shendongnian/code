    using System;
    
    namespace ConsoleApplication1
    {
        struct Test
        {
            // No TryParse method here!
        }
    
        static class Program
        {
            static void Main(string[] args)
            {
                var invalidTest = "12345".ParseTo<DateTime>();
                var validTest = "12345".ParseTo<int>();
                var veryInvalidTest = "12345".ParseTo<Test>();
    
                Console.WriteLine(!invalidTest.HasValue ? "<null>" : invalidTest.Value.ToString());
                Console.WriteLine(!validTest.HasValue ? "<null>" : validTest.Value.ToString());
            }
    
            public static T? ParseTo<T>(this string test) where T : struct
            {
                var method = typeof(T).GetMethod("TryParse", new Type[] { typeof(string), typeof(T).MakeByRefType() });
    
                if (method == null)
                    throw new Exception(); // or return null or whatever
    
                var parameters = new object[] { test, null };
    
                if ((bool)method.Invoke(null, parameters))
                {
                    return (T)parameters[1];
                }
                else
                    return null;
            }
        }
    }
