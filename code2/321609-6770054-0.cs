    var inQuotes = false;
    var sb = new StringBuilder(someText.Length);
    for (var i = 0; i < someText.Length; ++i)
    {
        if (someText[i] == '"')
        {
            inQuotes = !inQuotes;
        }
        if (inQuotes && someText[i] == ',')
        {
            sb.Append('$');
        }
        else
        {
            sb.Append(someText[i]);
        }
    }
