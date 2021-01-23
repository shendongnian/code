    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    [AttributeUsage(AttributeTargets.All,AllowMultiple=false,Inherited=true)]
    internal class TestAttribute : Attribute
    {
    }
    internal class Test
    {
        [event: Test]
        [field: Test]
        [method: Test]
        public event Action action;
        
        static void Main() 
        {
            MethodInfo method = typeof(Test).GetEvent("action")
                                            .GetRemoveMethod(); // Or GetAddMethod
            Console.WriteLine(method.IsDefined(typeof(TestAttribute), true));
        }
    }
