    public inputClass(string input, NumberFormatInfo numberFormat)
    {
        var dict = input
                     .Split(';')
                     .ToDictionary(
                        y => y.Split('=')[0],
                        y => y.Split('=')[1]
                     );
        I = decimal.Parse(dict["I"], numberFormat);
        A = decimal.Parse(dict["A"], numberFormat);
        D = decimal.Parse(dict["D"], numberFormat);
    }
    
