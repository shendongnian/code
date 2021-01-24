    using System;
    
    class Test
    {
        static int Method() => 5;
        
        static void Main()
        {
            Action action = () => Method();
        }
    }
