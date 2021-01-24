    using System;
    
    public class Program
    {
        const float scale = 64 * 1024;
    
        public static void Main()
        {
            Console.WriteLine(unchecked((uint)(ulong)(1.2 * scale * scale + 1.5 * scale)));
            Console.WriteLine(unchecked((uint)(scale * scale + 7.0)));
        }
    }
