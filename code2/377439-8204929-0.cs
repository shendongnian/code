    using System;
    using System.Threading;
    
    public class OddFinalizer   
    {
        int field;
        
        public OddFinalizer(int field)
        {
            this.field = field;
        }
        
        ~OddFinalizer()
        {
            Console.WriteLine("OddFinalizer");
        }
        
        public void Work()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("In loop before last access...");
                GC.Collect();
                GC.WaitForPendingFinalizers();            
                Thread.Sleep(1000);
            }
            Console.WriteLine("Field value: {0}", field);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("In loop after last access...");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            new OddFinalizer(10).Work();
        }
    }
