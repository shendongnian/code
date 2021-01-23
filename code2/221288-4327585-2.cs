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
            MethodInfo method = typeof(OtherClass).GetMethod("Foo",
                BindingFlags.InvokeMethod | BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.NonPublic);
            
            // Could now check for method being null etc
            method.Invoke(target, null);
        }
    }
