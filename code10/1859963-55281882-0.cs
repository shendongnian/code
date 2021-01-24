    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var list = new List<string>();
            list[0] = "test"; // Bang: ArgumentOutOfRangeException
        }
    }
