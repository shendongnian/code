    using System;
    
    class C : IDisposable
    {
        public void UseLimitedResource()
        {
            Console.WriteLine("Using limited resource...");
        }
    
        void IDisposable.Dispose()
        {
            Console.WriteLine("Disposing limited resource.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            using (C c = new C())
            {
                c.UseLimitedResource();
            }
            Console.WriteLine("Now outside using statement.");
            Console.ReadLine();
        }
    }
