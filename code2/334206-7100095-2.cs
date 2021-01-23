        public static double Round(double input, int decimalPlaces,int roundType = 0)
        {
            if(roundType == 0 && decimalPlaces >= 0)
            {
                return Math.Round(input, decimalPlaces);
            }
            double factor = Math.Pow(10, decimalPlaces);
            return Math.Truncate(input * factor) / factor;
        }
