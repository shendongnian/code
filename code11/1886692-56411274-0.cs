    using System;
    using System.Numerics;
    
    namespace BlumBlumSnub
    {
        class Program
        {
            public static readonly BigInteger p = 3263849;
            public static readonly BigInteger q = 1302498943;
            public static readonly BigInteger m = p*q;
    
            public static BigInteger next(BigInteger prev) {
                return (prev*prev) % m;
            }
    
            public static int parity(BigInteger n) {
                BigInteger q = n;
                BigInteger count = 0;
                while (q != BigInteger.Zero) {
                    count += q & BigInteger.One;
                    q >>= 1;
                }
                return ((count & BigInteger.One) != BigInteger.Zero) ? 1 : 0; // even parity
            }
    
            static void Main(string[] args)
            {
                BigInteger seed = 6367859;
    
                BigInteger xprev = seed;
                for(int k = 0; k != 100; ++k) {
                    BigInteger xnext = next(xprev);
                    int bit = parity(xnext); // extract random bit from generated BBS number
                    Console.WriteLine($"Bit = {bit}");
                    xprev = xnext;
                }
            }
        }
    }
