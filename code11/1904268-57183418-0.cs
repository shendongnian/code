    /// <summary>
    /// Gets the SQL value as German characters of codepage 1252.
    /// </summary>
    /// <param name="input">The string to convert for the target database.</param>
    /// <param name="isStringValue">if set to <c>true</c> return encapsulated in single quotation marks.</param>
    /// <returns>"''", or the value itself.</returns>
    protected string GetSqlValue(string input, bool isStringValue = true)
    {
        if (string.IsNullOrWhiteSpace(input)) return "''";
        else
        {
            Encoding targetEncoding = Encoding.GetEncoding(1252);
            // Remove all characters that are not part of codepage 1252.
            input = targetEncoding.GetString(targetEncoding.GetBytes(input));
            // Remove unsupported special characters.
            byte[] tmp = targetEncoding.GetBytes(input);
            for (int i = 0; i < tmp.Length; i++)
            {
                // Don't delete German umlauts.
                if (tmp[i] == 0xc4 /* Ä */ || tmp[i] == 0xe4 /* ä */ || tmp[i] == 0xd6 /* Ö */ || tmp[i] == 0xf6 /* ö */ || tmp[i] == 0xdc /* Ü */ || tmp[i] == 0xfc /* ü */) continue;
                // Delete non German characters and all kind of apostrophes.
                if (tmp[i] >= 0x80 || tmp[i] < 0x20 || tmp[i] == 0x27 || tmp[i] == 0x60) tmp = tmp.Where((source, index) => index != i).ToArray();
            }
            input = targetEncoding.GetString(tmp);
            if (isStringValue) return "'" + input + "'";
            else return input;
        }
    }
