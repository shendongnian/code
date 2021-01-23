    using System;
    using Jint;
    
    class Program
    {
        static void Main()
        {
            var script = @"
    function Add(a, b) {  
        return a + b;
    }
    
    function Substract(a, b) {  
        return a - b;
    }
    
    return Add(a, b);
    ";
            var result = new JintEngine()
                .SetParameter("a", 3)
                .SetParameter("b", 5)
                .Run(script);
    
            Console.WriteLine("result: {0}", result);
        }
    }
