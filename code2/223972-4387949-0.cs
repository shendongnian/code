    using System.Collections.Generic;
    int Convert(string s)
    {
        return Int32.Parse(s);
    }
    int[] result = Array.ConvertAll(input, new Converter<string, int>(Convert));
