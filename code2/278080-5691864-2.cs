        public static string BignumBignumProduct(string a, string b)
        {
            // NOTE no error checking for bad input or possible overflow...
            BigInteger num1 = new BigInteger(Convert.ToInt64(a));
            BigInteger num2 = new BigInteger(Convert.ToInt64(b));
            return ((num1*num2).ToString());
        }
