    private string toArabicNumber(string input)
    {
        var arabic = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        for (int j = 0; j < arabic.Length; j++)
        {
            input = input.Replace(j.ToString(), arabic[j]);
        }
        return input;
    }
