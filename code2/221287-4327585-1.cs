    using System;
    using System.Reflection;
    
    class OtherClass
    {
        private void Foo()
        {
            Console.WriteLine("OtherClass.Foo");
        }
    }
    
    class Test
    {
        static void Main()
        {
            OtherClass target = new OtherClass();
            typeof(OtherClass).InvokeMember("Foo",
                BindingFlags.InvokeMethod | BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.NonPublic,
                null, target, new object[0]);
        }
    }
