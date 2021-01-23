    using System;
    using System.Reflection;
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            Type unboundGenericType = typeof(MyClass<>);
            Type boundGenericType = unboundGenericType.MakeGenericType(typeof(string));
            MethodInfo doSomethingMethod = boundGenericType.GetMethod("DoSomething");
            object instance = Activator.CreateInstance(boundGenericType);
            doSomethingMethod.Invoke(instance, new object[] { "Hello" });
        }
        private sealed class MyClass<T>
        {
            public void DoSomething(T obj)
            {
                Console.WriteLine(obj);
            }
        }
    }
