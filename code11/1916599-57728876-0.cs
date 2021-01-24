    public static class ExtentionMethodConvertGBPtoBGN
    {
       //extension mathod
        public static double ConvertGBPtoBGN(this Conversion obj, double BGNmoney, double conversionrate)
        {
            return BGNmoney * conversionrate;
        }
        //non-extension mathod
        public static double ConvertGBPtoBGN(double BGNmoney, double conversionrate)
        {
            return BGNmoney * conversionrate;
        }
    }
