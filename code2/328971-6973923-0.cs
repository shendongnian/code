    public static string ToArabic(string input, string cultureName)
    {
        CultureInfo culture= new CultureInfo(cultureName);
        var arabicDigits = culture.NumberFormat.NativeDigits;
        for (int i = 0; i < arabicDigits.Length; i++)
        {
           input = input.Replace(i.ToString(), arabicDigits[i]);
        }
        return input;
    }
    
