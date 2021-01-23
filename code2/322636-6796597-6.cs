    // Create a regular expression to identify the last column after the whitespace
    Regex pattern = new Regex("\\s+\\S+$");
    // Dimension an array large enough
    string[] items = new string[lbContent.Items.Count];
    // Copy the items
    lbContent.Items.CopyTo(items, 0);
    // Use an orderby to sort and convert resulting IEnumerable<> back to array
    items = (from i in items
             let m = pattern.Match(i).Value
             orderby m.Trim()).ToArray();
    // Place it back in the collection
    lbContent.Items.Clear();
    lbContent.Items.AddRange(items);
