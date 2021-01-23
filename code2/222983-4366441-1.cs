        public static string NumbersOnly(this string Instring)
        {
            return Instring.NumbersOnly("");
        }
        public static string NumbersOnly(this string Instring, string AlsoAllowed)
        {
            char[] aChar = Instring.ToCharArray();
            int intCount = 0;
            string strTemp = "";
            for (intCount = 0; intCount <= Instring.Length - 1; intCount++)
            {
                if (char.IsNumber(aChar[intCount]) || AlsoAllowed.IndexOf(aChar[intCount]) > -1)
                {
                    strTemp = strTemp + aChar[intCount];
                }
            }
            return strTemp;
        }
