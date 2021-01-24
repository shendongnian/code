    using System;
    
    namespace Bob
    {
        public class Disposable : IDisposable
        {
            private int _property;
    
            public int Property { get => _property; set => throw new Exception(); }
    
            public void Dispose()
            {
                Console.WriteLine("Disposed");
            }
        }
    
        public class Program
        {
            public static void Main()
            {
                Console.WriteLine("1");
                using (var resource = new Disposable())
                {
                    Console.WriteLine("2");
                }
                Console.WriteLine("3");
    
    
                using (var resource = new Disposable() { Property = 1 })
                {
                    Console.WriteLine("4");
    
                }
                Console.WriteLine("5");
            }
        }
    }
