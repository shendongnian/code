    using System;
    
    public sealed class Bang
    {
        static Bang()
        {
            Console.WriteLine("In static constructor");
            throw new Exception("Bang!");
        }
        
        public static void Foo() {}
    }
    
    class Test
    {
        static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Bang.Foo();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType().Name);
                }
            }
        }
    }
