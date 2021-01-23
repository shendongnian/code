    using System;
    using System.Reflection;
    
    public delegate void TestHandler();
    
    public class A  
    {
        static void Main()
        {
            // This test does everything in the same assembly just
            // for simplicity
            Type type = typeof(B);
            Object o = Activator.CreateInstance(type);
            
            TestHandler handler = Foo;
            type.GetEvent("Test").AddEventHandler(o, handler);
            type.InvokeMember("Hello",
                              BindingFlags.Instance | 
                              BindingFlags.Public |
                              BindingFlags.InvokeMethod,
                              null, o, null);
        }
        
        private static void Foo()
        {
            Console.WriteLine("In Foo!");
        }
    }
    
    public class B
    {
        public event TestHandler Test;
        
        public string Hello()
        {
            TestHandler handler = Test;
            if (handler != null)
            {
                handler();
            }
            return "Hello";
        }
    }
