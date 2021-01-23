    // First create a list of unique elements
    List<string> ids = new List<string>();
    foreach (var account in RequestContext.accounts)
    {
        string id = account.uniqueid;
        if (ids.Contains(id))
        {
            ids.Add(id);
        }
    }
    // Then convert it into a string.
    // You could use string.Join(",", ids.ToArray()) here instead.
    StringBuilder builder = new StringBuilder();
    foreach (string id in ids)
    {
        builder.Append(id);
        builder.Append(",");
    }
    if (builder.Length > 0)
    {
        builder.Length--; // Chop off the trailing comma
    }
    return builder.ToString();
