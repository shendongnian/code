    public static String ToRegionalNumber(this String str) {
        String regionalNb = str.Replace(",", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
        regionalNb = regionalNb .Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
        return regionalNb ;
    }
