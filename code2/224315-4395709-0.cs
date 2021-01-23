    using System;
    using System.Numerics;
    using System.Collections.Generic;
    
    namespace DivTest
    {
        class Divide
        {
            public static decimal MyDivide(decimal num, decimal denom)
            {
                var quotient = num / denom;
                // turn decimals into BigInts
                int nExp, dExp, qExp;
                var nMan = MantissaOfDecimal(num, out nExp);
                var dMan = MantissaOfDecimal(denom, out dExp);
                var qMan = MantissaOfDecimal(quotient, out qExp);
                // multiply quotient times denominator and compare with numerator
                if (dMan * qMan > nMan * BigInteger.Pow(10, dExp + qExp - nExp))
                {
                    // quotient was rounded away from zero, so subtract LSB
                    // to round back toward zero
                    quotient -= new decimal(1, 0, 0, quotient < 0, (byte)qExp);
                }
                return quotient;
            }
    
            static BigInteger MantissaOfDecimal(decimal d, out int exponent)
            {
                var ints = decimal.GetBits(d);
                exponent = (ints[3] >> 16) & 0xFF;
                var bytes = new List<byte>(13);
                // create a BigInteger containing the mantissa of the decimal value
                bytes.AddRange(BitConverter.GetBytes(ints[0]));
                bytes.AddRange(BitConverter.GetBytes(ints[1]));
                bytes.AddRange(BitConverter.GetBytes(ints[2]));
                bytes.Add(0);
                return new BigInteger(bytes.ToArray());
            }
    
            static void Main()
            {
                decimal num = 2m, denom = 3m;
                Console.WriteLine("Divide:   " + num / denom);
                Console.WriteLine("MyDivide: " + MyDivide(num, denom));
            }
        }
    }
