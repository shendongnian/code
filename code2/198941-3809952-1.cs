    using System;
    using System.Reflection;
    
    class Test
    {
        public void testFunction1(int a, int b, ref int c)
        {
            c += a + b;
        }
    
        public void testFunction2(int a, int b, out int c)
        {
            c = a + b;
        }
    
        static void Main()
        {
            MethodInfo method = typeof(Test).GetMethod("testFunction1");
            object[] args = new object[] { 1, 2, 3 };
            Test instance = new Test();
            method.Invoke(instance, args);
            // The ref parameter will be updated in the array, so this prints 6
            Console.WriteLine(args[2]);
            
            method = typeof(Test).GetMethod("testFunction2");
            // The third argument here has to be of the right type,
            // but the method itself will ignore it
            args = new object[] { 1, 2, 999 };
            method.Invoke(instance, args);
            // The ref parameter will be updated in the array, so this prints 3
            Console.WriteLine(args[2]);
        }
    }
