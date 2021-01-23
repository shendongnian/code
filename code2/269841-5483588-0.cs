    String[] contents = input.ReadToEnd()
        .ToLower()
        .Replace(",", "")
        .Replace("(", "")
        .Replace(")", "")
        .Replace(".", "")
        .Split("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
