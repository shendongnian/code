    private bool BitExists(string value, string key)
    {
        int k = Int32.Parse(key, System.Globalization.NumberStyles.AllowHexSpecifier);
        return (Int32.Parse(value) & k) == k;
    }
