    using System;
    public class Program
    {
        const float scale = 64 * 1024;
    
        public static void Main()
        {
            Console.WriteLine(unchecked((uint)(ulong)(1.2 * scale * scale + 1.5 * scale))); // 859091763
            Console.WriteLine(unchecked((uint)(ulong)(scale * scale + 7.0))); // 7
        }
    }
