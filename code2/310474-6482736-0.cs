    StringBuilder result = new StringBuilder();
    for (var i = 0; i < data.Length; i++)
    {
        if (i > 0 && (i % 4) == 0)
            result.Append("-");
        result.Append(chars[data[i] % (chars.Length - 1)]);
    }
    result.Length -= 1; // Remove trailing '-'
