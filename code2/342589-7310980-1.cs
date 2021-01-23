    /// <summary>
    /// Converts the specified byte array into a delimited list of hex pairs.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="requiredLength">The required length (in bytes) required.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The binary value.</returns>
    static string ToBinaryString(byte[] values, int requiredLength, string delimiter, bool allowLonger)
    {
        if (values == null)
            return null;
        if (values.Length > requiredLength)
        {
            if (allowLonger)
                requiredLength = values.Length;
            else
                throw new ArgumentOutOfRangeException("values");
        }
        // Create the StringBuilder with the precise length of values.
        var sb = new StringBuilder((2 + delimiter.Length) * requiredLength - delimiter.Length);
        var padLength = requiredLength - values.Length;
        for (var i = 0; i < padLength; i++)
            sb.Append(sb.Length == 0 ? "" : delimiter)
              .Append("00");
        for (var i = 0; i < values.Length; i++)
            sb.Append(sb.Length == 0 ? "" : delimiter)
              .Append(values[i].ToString("x2"));
        return sb.ToString();
    }
    /// <summary>
    /// Converts the specified byte array into a delimited list of hex pairs.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>
    /// The binary value.
    /// </returns>
    static string ToBinaryString(byte[] values, string delimiter)
    {
        return ToBinaryString(values, 0, delimiter, true);
    }
