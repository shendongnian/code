    using System;
    using System.Numerics;
    
    public static class DecimalExtensions
    {
        // Avoiding implicit conversions just for clarity
        private static readonly BigInteger Ten = new BigInteger(10);
        private static readonly BigInteger UInt32Mask = new BigInteger(0xffffffffU);
        
        public static decimal Normalize(this decimal input)
        {
            unchecked
            {
                int[] bits = decimal.GetBits(input);
                BigInteger mantissa = 
                    new BigInteger((uint) bits[0]) +
                    (new BigInteger((uint) bits[1]) << 32) +
                    (new BigInteger((uint) bits[2]) << 64);
                
                int sign = bits[3] & int.MinValue;            
                int exponent = (bits[3] & 0xff0000) >> 16;
                            
                // The loop condition here is ugly, because we want
                // to do both the DivRem part and the exponent check :(
                while (exponent > 0)
                {
                    BigInteger remainder;
                    BigInteger divided = BigInteger.DivRem(mantissa, Ten, out remainder);
                    if (remainder != BigInteger.Zero)
                    {
                        break;
                    }
                    exponent--;
                    mantissa = divided;
                }
                // Okay, now put it all back together again...
                bits[3] = (exponent << 16) | sign;
                // For each 32 bits, convert the bottom 32 bits into a uint (which won't
                // overflow) and then cast to int (which will respect the bits, which
                // is what we want)
                bits[0] = (int) (uint) (mantissa & UInt32Mask);
                mantissa >>= 32;
                bits[1] = (int) (uint) (mantissa & UInt32Mask);
                mantissa >>= 32;
                bits[2] = (int) (uint) (mantissa & UInt32Mask);
                
                return new decimal(bits);
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                Check(6.000m);
                Check(6000m);
                Check(6m);
                Check(60.00m);
                Check(12345.00100m);
                Check(-100.00m);
            }
            
            static void Check(decimal d)
            {
                Console.WriteLine("Before: {0}  -  after: {1}", d, d.Normalize());
            }
        }
    }
