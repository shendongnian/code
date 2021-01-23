    static string BinToHex(string bin)
    {
        if (bin == null)
            throw new ArgumentNullException("bin");
        if (bin.Length % 8 != 0)
            throw new ArgumentException("The length must be a multiple of 8", "bin");
        var hex = Enumerable.Range(0, bin.Length / 8)
                         .Select(i => bin.Substring(8 * i, 8))
                         .Select(s => Convert.ToByte(s, 2))
                         .Select(b => b.ToString("x2"));
        return String.Join(null, hex);
    }
