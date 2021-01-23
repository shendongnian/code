    using System;
    
    public class Foo
    {
        public static implicit operator int(Foo input)
        {
            return 0;
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            foreach (var method in typeof(Foo).GetMethods())
            {
                Console.WriteLine(method + ": " + method.IsSpecialName);
            }
        }
    }
