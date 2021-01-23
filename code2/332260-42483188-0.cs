    public static Int64 generate_Digits(int length)
    {
        var fullString = string.Join("", System.Text.Encoding.ASCII.GetBytes(Guid.NewGuid().ToString("N")).Select(o => o.ToString()));
        return Convert.ToInt16(fullString.Substring(0, length));
    }
