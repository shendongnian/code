    string ConvertToFuzzyFrogBinary(int input)
    {
        int prefix = (input).ToString("d8").Length-(Math.Abs((input))).ToString("d8").Length;
        string binary_num = "00000000000000000000000000000000".Substring(0,32-Convert.ToString(Math.Abs(input),2).Length)+Convert.ToString(Math.Abs(input),2);
        return "1".Substring(0,prefix)+binary_num.Substring(prefix,32-prefix);
    }
