    using System;
    
    public delegate int ReturnedDelegate(string s);
    
    class AnonymousDelegate
    {
        static void Main()
        {
            ReturnedDelegate len = delegate(string s)
            {
                return s.Length;
            };
            Console.WriteLine(len("hello world"));
        }
    }
