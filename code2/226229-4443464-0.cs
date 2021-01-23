    using System;
    using System.Reflection;
    using System.Linq;
    
    public class Foo
    {
        public void Bar<T>(Func<T> f) { }
        public void Bar<T>(Action<T> a) { }
    }
    
    class Test
    {
        static void Main()
        {
            var methods = from method in typeof(Foo).GetMethods()
                          where method.Name == "Bar"
                          let typeArgs = method.GetGenericArguments()
                          where typeArgs.Length == 1
                          let parameters = method.GetParameters()
                          where parameters.Length == 1
                          where parameters[0].ParameterType == 
                                typeof(Func<>).MakeGenericType(typeArgs[0])
                          select method;
            
            Console.WriteLine("Matching methods...");
            foreach (var method in methods)
            {
                Console.WriteLine(method);
            }
        }
    }
