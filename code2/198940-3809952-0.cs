    using System;
    using System.Reflection;
    
    class Test
    {
        public void testFunction(int a, int b, ref int c)
        {
            c += a + b;
        }
        
        static void Main()
        {
            MethodInfo method = typeof(Test).GetMethod("testFunction");
            object[] args = new object[] { 1, 2, 3 };
            Test instance = new Test();
            method.Invoke(instance, args);
            // The ref parameter will be updated in the array, so this prints 6
            Console.WriteLine(args[2]);
        }
    }
