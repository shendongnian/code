    using System;
    
    class Example
    {
        static void Main()
        {
            Example example = null;
    
            // this is always "false"
            Console.WriteLine(example is Example);
        }
    }
