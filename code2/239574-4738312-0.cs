    using System;
    using System.Reflection;
    
    class Test
    {
        public static void Foo<T>(T item)
        {
            Console.WriteLine("{0}: {1}", typeof(T), item);
        }
    
        static void CallByReflection(string name, Type typeArg,
                                     object value)
        {
            // Just for simplicity, assume it's public etc
            MethodInfo method = typeof(Test).GetMethod(name);
            MethodInfo generic = method.MakeGenericMethod(typeArg);
            generic.Invoke(null, new object[] { value });
        }
        
        static void Main()
        {
            CallByReflection("Foo", typeof(object), "actually a string");
            CallByReflection("Foo", typeof(string), "still a string");
            // This would throw an exception
            // CallByReflection("Foo", typeof(int), "oops");
        }
    }
