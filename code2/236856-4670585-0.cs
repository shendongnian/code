    using System;
    
    public class Test
    {
        static void Main(string[] args)
        {
            object o = new object();
            Register(o, (s, e) => {});
        }
        
        static void Register(object source, EventHandler handler)
        {
            Console.WriteLine("Handler");
        }
    
        static void Register(object source, string text)
        {
            Console.WriteLine("Text");
        }
    }
