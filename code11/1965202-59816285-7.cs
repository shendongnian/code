    using System;
    
    public class Program
    {
        static Random random = new Random();
    
        public static void Main()
        {
            var scale = 64 * random.Next(1024, 1025);		
    		uint f = (uint)(ulong)(scale * scale + 7f);
    		uint d = (uint)(ulong)(scale * scale + 7d);
    		uint i = (uint)(ulong)(scale * scale + 7);
    		
            Console.WriteLine((uint)(ulong)(1.2 * scale * scale + 1.5 * scale)); // 859091763
            Console.WriteLine((uint)(ulong)(scale * scale + 7f)); // 7
    		Console.WriteLine(f); // 7
    		Console.WriteLine((uint)(ulong)(scale * scale + 7d)); // 7
    		Console.WriteLine(d); // 7
    		Console.WriteLine((uint)(ulong)(scale * scale + 7)); // 7
    		Console.WriteLine(i); // 7
        }
    }
