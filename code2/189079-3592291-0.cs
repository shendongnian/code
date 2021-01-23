    using System;
    
    class Test1
    {
        static int x = GetX();
        static int y = 0;
        
        public static void Hello()
        {
            Console.WriteLine("{0} {1}", x, y);
        }
        
        static int GetX()
        {
            y = 2;
            return 5;
        }
    }
    
    class Test2
    {
        static int x = GetX();
        static int y;
    
        public static void Hello()
        {
            Console.WriteLine("{0} {1}", x, y);
        }
    
        static int GetX()
        {
            y = 2;
            return 5;
        }
    }
    
    class Test
    {
        static void Main()
        {
            Test1.Hello();
            Test2.Hello(); 
        }
    }
