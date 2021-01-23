    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            string[] strings = { "a", "b" };
            var results = strings.Select(MyFunc);
        }
        
        static bool MyFunc(string input)
        {
            return true;
        }
    }
