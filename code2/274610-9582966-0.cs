    /// <summary>
    /// Formats a request cookie string from the cookies received from the authentication service
    /// </summary>
    /// <param name="input">The cookie string received from the authentications service</param>
    /// <returns>A formatted cookie string to send to data requests</returns>
    private static string FormatCookie(string input)
    {
        string[] cookies = input.Split(new char[] { ',', ';' });
        StringBuilder buffer = new StringBuilder(input.Length * 10);
        foreach (string entry in cookies)
        {
            if (entry.IndexOf("=") > 0 && !entry.Trim().StartsWith("path") && !entry.Trim().StartsWith("expires"))
            {
                buffer.Append(entry).Append("; ");
            }
        }
        if (buffer.Length > 0)
        {
            buffer.Remove(buffer.Length - 2, 2);
        }
        return buffer.ToString();
    }
