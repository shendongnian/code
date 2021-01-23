    /// <summary>
    /// Gets the System.Drawing.Color object from hex string.
    /// </summary>
    /// <param name="hexString">The hex string.</param>
    /// <returns></returns>
    private System.Drawing.Color GetSystemDrawingColorFromHexString(string hexString)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(hexString, @"[#]([0-9]|[a-f]|[A-F]){6}\b"))
            throw new ArgumentException();
        int red = int.Parse(hexString.Substring(1, 2), NumberStyles.HexNumber);
        int green = int.Parse(hexString.Substring(3, 2), NumberStyles.HexNumber);
        int blue = int.Parse(hexString.Substring(5, 2), NumberStyles.HexNumber);
        return Color.FromArgb(red, green, blue);
    }
