    private string HexString2Ascii(string hexString)
    {
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i <= hexString.Length - 2; i += 2)
    {
    sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
    }
    return sb.ToString();
    }
