    using System;
    class Program
    {
        enum IntEnum : int { A }
        static void Main(string[] args)
        {
            var intEnum = IntEnum.A;
            Console.WriteLine(intEnum.GetType().GetEnumUnderlyingType());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }       
    }
