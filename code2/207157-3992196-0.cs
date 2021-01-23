    using System;
    using System.Runtime.CompilerServices;
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Call1();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        static void Call1()
        {
            Call2();
        }
    
        static void Call2()
        {
            Call3();
        }
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Call3()
        {
            Call4();
        }
        
        static void Call4()
        {
            Call5();
        }
        
        static void Call5()
        {
            throw new Exception();
        }
    }
