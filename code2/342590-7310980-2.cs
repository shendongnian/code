    /// <summary>
    /// Converts the specified <see cref="Int32"/> into a delimited list of hex pairs.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The binary value.</returns>
    static string ToBinaryString(int value, string delimeter)
    {
        var u = (uint)IPAddress.HostToNetworkOrder(value);
        var sb = new StringBuilder((2 + delimeter.Length) * 4 - delimeter.Length);
        sb.Append(((u >> 0) & 0xFF).ToString("x2")).Append(delimeter);
        sb.Append(((u >> 8) & 0xFF).ToString("x2")).Append(delimeter);
        sb.Append(((u >> 16) & 0xFF).ToString("x2")).Append(delimeter);
        sb.Append(((u >> 24) & 0xFF).ToString("x2"));
        return sb.ToString();
    }
