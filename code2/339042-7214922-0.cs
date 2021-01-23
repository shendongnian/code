    using System;
    using System.Numerics;
    
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger bigValue = new BigInteger(ulong.MaxValue);
            
            long x = ConvertToInt64Unchecked(bigValue);
            Console.WriteLine(x);
        }
        
        private static readonly BigInteger MaxUInt64AsBigInteger
            = ulong.MaxValue;
        
        private static long ConvertToInt64Unchecked(BigInteger input)
        {
            unchecked
            {
                return (long) (ulong) (input & MaxUInt64AsBigInteger);
            }
        }
    }
