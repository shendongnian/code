    namespace Test
    {
    
        class Program
        {
            const string format = @"hh\:mm\:ss\,fff";
            static void Main(string[] args)
            {
                Console.WriteLine(Invoke("Test.Apple", "GetInstance"));
                Console.WriteLine(Invoke("Test.Banana", "GetInstance"));
            }
            public static object Invoke(string type, string method)
            {
                Type t = Type.GetType(type);
                object o = t.InvokeMember(method, BindingFlags.InvokeMethod, null, t, new object[0]);
                return o;
            }
    
            }
            class Apple 
            {
                public static Apple GetInstance() { return new Apple(); }
                private Apple() { }
    
                // other stuff
            }
    
            class Banana
            {
                public static Banana GetInstance() { return new Banana(); }
                private Banana() { }
    
                // other stuff
            }
    
    }
