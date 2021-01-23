    public bool IsHexString(string hexString)
    {
        System.Globalization.CultureInfo provider = new System.Globalization.CultureInfo("en-US");
        int output = 0;
        return Int32.TryParse(hexString, System.Globalization.NumberStyles.HexNumber, provider, out output))
    }    
