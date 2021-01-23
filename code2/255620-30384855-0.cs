    //Written By Brian Dobony
    public static class Fraction
    {
        public static string ConvertDecimal(Double NumberToConvert, int DenominatorPercision = 32)
        {
            int WholeNumber = (int)NumberToConvert;
            double DecimalValue = NumberToConvert - WholeNumber;
            double difference = 1;
            int numerator = 1;
            int denominator = 1;
            // find closest value that matches percision
            // Automatically finds Fraction in simplified form
            for (int y = 2; y < DenominatorPercision + 1; y++)
            {
                    for (int x = 1; x < y; x++)
                    {
                        double tempdif = Math.Abs(DecimalValue - (double)x / (double)y);
                        if (tempdif < difference)
                        {
                            numerator = x;
                            denominator = y;
                            difference = tempdif;
                            // if exact match is found return it
                            if (difference == 0)
                            {
                                return FractionBuilder(WholeNumber, numerator, denominator);
                            }
                        }
                    }
            }
            return FractionBuilder(WholeNumber, numerator, denominator);
        }
        private static string FractionBuilder(int WholeNumber, int Numerator, int Denominator)
        {
            if (WholeNumber == 0)
            {
                return Numerator + @"/" + Denominator;
            }
            else
            {
                return WholeNumber + " " + Numerator + @"/" + Denominator;
            }
        }
    }
