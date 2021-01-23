        public static double DoubleFromHex(string hex)
        {
            int exponent;
            double result;
            string doubleexponenthex = hex.Substring(0, 3);
            string doublemantissahex = hex.Substring(3);
            double mantissavalue = 1; //yes this is how it works
            for (int i = 0; i < doublemantissahex.Length; i++)
            {
                int hexsignvalue = Convert.ToInt32(doublemantissahex.Substring(i, 1),16); //Convert ,16 Converts from Hex
                mantissavalue += hexsignvalue * (1 / Math.Pow(16, i+1));
            }
            exponent = Convert.ToInt32(doubleexponenthex, 16);
            exponent = exponent - 1023;  //just how it works
            result = Math.Pow(2, exponent) * mantissavalue;
            return result;
        }
