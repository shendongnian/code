    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            byte[] bytes = Enumerable.Range(0, 16)
                                     .Select(x => x * 16 + x)
                                     .Select(x => (byte) x)
                                     .ToArray();
            
            Console.WriteLine(BitConverter.ToString(bytes).Replace("-", ""));
            Console.WriteLine(new Guid(bytes).ToString().Replace("-", ""));
        }
    }
