        static void Main(string[] args)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 2;
            decimal s;
            if (decimal.TryParse("2.01", NumberStyles.AllowDecimalPoint, nfi, out s) && CountDecimalPlaces(s) < 3)
            {
                Console.WriteLine("Passed");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Failed");
            Console.ReadLine();
        }
        static decimal CountDecimalPlaces(decimal dec)
        {
            int[] bits = Decimal.GetBits(dec);
            int exponent = bits[3] >> 16;
            int result = exponent;
            long lowDecimal = bits[0] | (bits[1] >> 8);
            while ((lowDecimal % 10) == 0)
            {
                result--;
                lowDecimal /= 10;
            }
            return result;
        }
