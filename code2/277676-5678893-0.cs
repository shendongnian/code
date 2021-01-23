    // Here original represents the string you're converting from.
    string[] splits = original.Split(
        new[] { "•" },
        StringSplitOptions.RemoveEmptyEntries);
    var htmlBuilder = new StringBuilder();
    for (int i = 0; i < splits.Length; i++)
    {
        if (i != 0)
        {
            if (i == 1)
            {
                htmlBuilder.Append("<ul><li>");
            }
            else if (i != splits.Length - 1)
            {
                htmlBuilder.Append("</li><li>");
            }
        }
    
        htmlBuilder.Append(splits[i]);
    }
    htmlBuilder.Append("</li><ul>");
