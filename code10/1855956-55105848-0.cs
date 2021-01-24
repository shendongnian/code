    namespace StackOverflow
    {
        using System;
        using System.Reflection;
    
        [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
        public class ExecuteMe : Attribute
        {
            public object[] Arguments { get; }
    
            public ExecuteMe(params object[] args)
            {
                this.Arguments = args;
            }
        }
    
        public class TestSubject
        {
            [ExecuteMe(5, "Hello")]
            [ExecuteMe(7, "World")]
            public int Function(int i, string s)
            {
                Console.WriteLine("Executing TestSubject.Function with parameters {0} and {1}", i, s);
    
                return 42;
            }
        }
    
        internal static class Program
        {
            internal static void Main(string[] args)
            {
                // This could come from another dll, for example
                // var assembly = Assembly.LoadFrom("MyLibrary.dll").GetTypes();
                var availableTypes = Assembly.GetExecutingAssembly().ExportedTypes;
    
                foreach (var type in availableTypes)
                {
                    foreach (var method in type.GetMethods())
                    {
                        foreach (var attribute in method.GetCustomAttributes<ExecuteMe>())
                        {
                            var instance = Activator.CreateInstance(type);
    
                            method.Invoke(instance, attribute.Arguments);
                        }
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
