    using System;
    class Test
    {
        int y;
        
        Test(int x = 0)
        {
            Console.WriteLine(x);
        }
        
        static void Main()
        {
            // This is still okay, even though there's no geniune parameterless
            // constructor
            Test t = new Test
            {
                y = 10
            };
        }
    }
