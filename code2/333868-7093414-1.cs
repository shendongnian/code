    // keyword_enum2.cs
    // Using long enumerators
    using System;
    public class EnumTest 
    {
        enum Range :long {Max = 2147483648L, Min = 255L};
        static void Main() 
        {
            long x = (long)Range.Max;
            long y = (long)Range.Min;
            Console.WriteLine("Max = {0}", x);
            Console.WriteLine("Min = {0}", y);
        }
    }
