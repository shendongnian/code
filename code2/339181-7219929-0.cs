    private string RestoreText(string text)
    {
        var sb = new StringBuilder();
        var totalLen = 0;
        var orgIndex = 0;
        foreach (var pair in _tags.OrderBy(t => t.Key))
        {
            var toAdd = text.Substring(orgIndex, pair.Key - totalLen);
            sb.Append(toAdd);
            orgIndex += toAdd.Length;
            totalLen += toAdd.Length;
            sb.Append(pair.Value);
            totalLen += pair.Value.Length;
        }
        if (orgIndex < text.Length) sb.Append(text.Substring(orgIndex));
        return sb.ToString();
    }
